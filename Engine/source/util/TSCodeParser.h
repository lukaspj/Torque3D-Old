#ifndef _STRINGBUFFER_H_
#include "core/stringBuffer.h"
#endif
#ifndef _UNICODE_H_
#include "core/strings/unicode.h"
#endif

#include "core/fileObject.h"

class TSCodeParser
{
	U32 mScanPos;

	enum codeElements{
		Keyword = BIT(0),
		Function = BIT(1),
		Varible = BIT(2),
		Comment = BIT(3),
		Break
	};

	struct Line
	{
		S32 startPos;
		S32 endPos;
	};

	struct object
	{
		S32 namePos;
		S32 nameLength;

		S32 classPos;
		S32 classLen;

		struct field
		{
			S32 namePos;
			S32 nameLength;
			S32 valuePos;
			S32 valueLength;
		};

		Vector<field> mFields;
	};

public:
	StringBuffer mTextBuffer;

	U32 mTextLength;

	Vector<Line> mLines;

	Vector<object> mObjects;

	//const char* findNextElement( U32 elementMask, S32 startPosition );
	//const char* findWord( const char* word, S32 startPosition );

	//void findObjectName(const char* objName, S32 startPosition );

	//const char* findAndReplace( const char* objName, S32 startPosition );

public:
	bool loadFile(const char* path);
	S32 find( const char* find, S32 startPosition );
	void findAndReplace( const char* fimd, const char* replace, S32 startPosition );
	//S32 findObjectName( S32 startPosition, const char* objName);
	S32 findObjectName( S32 startPosition, String &objName);
	//S32 getLineFromPosition( S32 startPosition );
	Line* getLineFromPosition( S32 position );
	Line getLine( S32 startPosition );

	const char* readLine(S32 startPos);

	const char* getCode();

	void execute();

	void buildObjectList();

	String getObjectField( S32 objectPos, String &fieldName);
};

static S32 getHexVal(char c)
{
   if(c >= '0' && c <= '9')
      return c - '0';
   else if(c >= 'A' && c <= 'Z')
      return c - 'A' + 10;
   else if(c >= 'a' && c <= 'z')
      return c - 'a' + 10;
   return -1;
}

static S32 scanforchar(const char *str, U32 idx, char c)
{
   U32 startidx = idx;
   while(str[idx] != c && str[idx] && str[idx] != '\n')
      idx++;
   return str[idx] == c && startidx != idx ? idx-startidx : -1;
}

static S32 scanforword(char *str, const char* word)
{
	const char* retpos = dStrstr( str, word );
   if( !retpos )
      return -1;
      
   return retpos - str;
}

static S32 scanforScriptTerminator(const char *str, U32 &idx)
{
   U32 startidx = idx;
   while(str[idx] && str[idx] != '[' && str[idx] != ']' && str[idx] != ';' && str[idx] != '(' 
	   && str[idx] != ')' && str[idx] != '-' && str[idx] != '*' && str[idx] != '/' && str[idx] != '+' 
	   && str[idx] != '%' && str[idx] != '&' && str[idx] != '@' && str[idx] != '$' && str[idx] != ' ' 
	   && str[idx] != ',' && str[idx] != '=' && str[idx] != '!' && str[idx] != '^' && str[idx] != '\''
	   && str[idx] != '|' && str[idx] != '{' && str[idx] != '}' && str[idx] != '\\' && str[idx] != '\t' 
	   && str[idx] != '.' && str[idx] != '\n')
      idx++;
   return startidx != idx ? idx-startidx : -1;
}

static bool isScriptTerminator(char str)
{
	if(str && str != '[' && str != ']' && str != ';' && str != '(' 
	   && str != ')' && str != '-' && str != '*' && str != '/' && str != '+' 
	   && str != '%' && str != '&' && str != '@' && str != '$' && str != ' ' 
	   && str != ',' && str != '=' && str != '!' && str != '^' && str != '\''
	   && str != '|' && str != '{' && str != '}' && str != '\\' && str != '\t' 
	   && str != '.' && str != '\n')
		return false;
	else
		return true;
}

static bool isTextTerminator(char str)
{
	if(str && str != '*' && str != '/' && str != '%' && str != '$' 
	   && str != '\'' && str != '\"' && str != '\n')
		return false;
	else
		return true;
}

static S32 scanforScriptOperator(const char *str, U32 &idx)
{
   U32 startidx = idx;
   while(str[idx] && str[idx] != '-' && str[idx] != '*' && str[idx] != '/' && str[idx] != '+' 
	   && str[idx] != '%' && str[idx] != '&' && str[idx] != '@' && str[idx] != '$' && str[idx] != '=' 
	   && str[idx] != '!' && str[idx] != '^' && str[idx] != '|')
      idx++;
   return startidx != idx ? idx : -1;
}

static U32 getWordCount(const char *string)
{
  U32 count = 0;
  U8 last = 0;
  const char *set = " \t\n";
  while(*string)
  {
     last = *string++;

     for(U32 i =0; set[i]; i++)
     {
        if(last == set[i])
        {
           count++;
           last = 0;
           break;
        }
     }
  }
  if(last)
     count++;
  return count;
}

static bool scanforURL(const char *str, U32 &idx, char c)
{
   U32 startidx = idx;
   while(str[idx] != c && str[idx] && str[idx] != '>' && str[idx] != '\n')
      idx++;
   return str[idx] == c && startidx != idx;
}

static const char* readLine(const char *str, S32 startPos)
{
	if(!str[0])
      return "";

	char *buf;
	dStrcpy(buf, str);

   U32 tokPos = startPos;
	U32 curPos = startPos;
	U32 len = strlen(str);

   for(;;)
   {
      if(curPos == len)
         break;

      if(buf[curPos] == '\r')
      {
         buf[curPos++] = 0;
         if(buf[curPos] == '\n')
            curPos++;
         break;
      }

      if(buf[curPos] == '\n')
      {
         buf[curPos++] = 0;
         break;
      }

      curPos++;
   }

   return buf + tokPos;

	//reads through the str from the start, and separates it into the first acceptable line
	/*U32 pos = startPos;
	U32 len = strlen(str);

   for(;;)
   {
      if(pos == len)
         break;

		
      if(str[pos] == '\r')
      {
         //str[pos++] = 0;
         if(str[pos++] == '\n')
            pos++;
         break;
      }

      if(str[pos] == '\n')
      {
         //str[pos++] = 0;
         break;
      }

      pos++;
   }

	
	char returnstr[2048];
	strncpy( returnstr, str + startPos, pos );
	returnstr[pos] = '\0';

   return returnstr;*/
}

const char* TSCodeParser::getCode() 
{ 
	return (const char*)mTextBuffer.createSubstring8(0, mTextLength);
}

const char* TSCodeParser::readLine(S32 startPos)
{
	U32 curPos = startPos;

	while(curPos < mTextLength)
	{
		char chr = (char)mTextBuffer.getChar(curPos);

      if(chr == '\r')
      {
			curPos++;

			if((char)mTextBuffer.getChar(curPos) == '\n')
				curPos++;

			break;
      }

      if(chr == '\r')
      {
         curPos++;
         break;
      }

      curPos++;
   }

	return (const char*)mTextBuffer.createSubstring8(startPos, curPos-startPos);

	//reads through the str from the start, and separates it into the first acceptable line
	/*U32 pos = startPos;
	U32 len = strlen(str);

   for(;;)
   {
      if(pos == len)
         break;

		
      if(str[pos] == '\r')
      {
         //str[pos++] = 0;
         if(str[pos++] == '\n')
            pos++;
         break;
      }

      if(str[pos] == '\n')
      {
         //str[pos++] = 0;
         break;
      }

      pos++;
   }

	
	char returnstr[2048];
	strncpy( returnstr, str + startPos, pos );
	returnstr[pos] = '\0';

   return returnstr;*/
}

/*void writeTabs(U32 count)
{
  while(count--)
     insertChars( "\t", 1, mCursorPosition );
}*/

/*const char* TSCodeParser::findNextElement( U32 elementMask, S32 startPosition )
{
	mScanPos = startPosition;

	for(;;)
   {
      UTF16 curChar = mTextBuffer.getChar(mScanPos);

      if(!curChar)
         break;

      if(curChar == '\n')
      {
         textStart = mScanPos;
         len = 1;
         mScanPos++;
         processEmitAtoms();
         emitNewLine(textStart);
         mCurDiv = 0;

		 if(!isSelectCommented)
		 {
			 if(mCurStyle->color != mProfile->mFontColor)
			 {
				if(mCurStyle->used)
					mCurStyle = allocStyle(mCurStyle);
				 mCurStyle->color = mProfile->mFontColor;
			 }
		 }
         continue;
      }

      if(curChar == '\t')
      {
         textStart = mScanPos;
         len = 1;
         mScanPos++;
         processEmitAtoms();
         if(mTabStopCount)
         {
            if(mCurTabStop < mTabStopCount)
            {
				mCurX += 22; //equivalent of 3 spaces
            }
            mCurTabStop++;
         }
         continue;
      }

	  //probably a variable
	  if(curChar == '%' || curChar == '$')
     {
		  //we may be starting a comment
		  const UTF8 *str = mTextBuffer.getPtr8();
		  str = getNthCodepoint(str, mScanPos);
		  U32 index = 1;

		  S32 t = scanforScriptTerminator(str, index);
		  if(t > 0)
		  {
			 //didn't return anything, we're a variable!
			 if(mCurStyle->used)
				mCurStyle = allocStyle(mCurStyle);

			 if(curChar == '%')
				mCurStyle->color = ColorI(0,160,128);
			 else
			    mCurStyle->color = ColorI(196,92,0);

			 //override
			textStart = mScanPos;
			idx = t+1;

			len = idx;
			mScanPos += idx;
			emitTextToken(textStart, len);

			if(mCurStyle->used)
			  mCurStyle = allocStyle(mCurStyle);
			mCurStyle->color = mProfile->mFontColor;
			continue;
		  }
		  else
			goto textemit;
	  }

	  if(curChar == '/')
	  {
		  //we may be starting a comment
		  const UTF8 *str = mTextBuffer.getPtr8();
		  str = getNthCodepoint(str, mScanPos);

		  if(!dStrnicmp(str + 1, "/", 1))
		  {
			  if(mCurStyle->used)
				   mCurStyle = allocStyle(mCurStyle);
			  mCurStyle->color = ColorI(0,100,0);

			  //override
			  textStart = mScanPos;
			  idx = 1;

			  while(mTextBuffer.getChar(mScanPos+idx) && mTextBuffer.getChar(mScanPos+idx) != '\n' )
				 idx++;
			  len = idx;
			  mScanPos += idx;
			  emitTextToken(textStart, len);

			  if(mCurStyle->used)
				  mCurStyle = allocStyle(mCurStyle);
			  mCurStyle->color = mProfile->mFontColor;
			  continue;
		  }
		  else if(!dStrnicmp(str + 1, "*", 1))
		  //else if(scanforchar(str, 1, '*'))
		  {
			//selective comment!
			isSelectCommented = true;
		  }
	  }

	  if(curChar == '\"'/* || curChar == '\''*//*)
	  {
		  //we may be starting a comment
		  const UTF8 *str = mTextBuffer.getPtr8();
		  str = getNthCodepoint(str, mScanPos);

		  if(mCurStyle->used)
			   mCurStyle = allocStyle(mCurStyle);
		  mCurStyle->color = ColorI(160,32,240);

		  //go looking for the end
		  S32 cIdx = scanforchar(str, idx, '\"');
		  if(cIdx == -1)
		  {
			  goto textemit;
		  }
		  else
		  {
			 if(mCurStyle->used)
				mCurStyle = allocStyle(mCurStyle);
			 mCurStyle->color = ColorI(160,32,240);

			 textStart = mScanPos;
			 idx = cIdx+1;

			 len = idx;
			 mScanPos += idx;
			 emitTextToken(textStart, len);

			 if(mCurStyle->used)
				 mCurStyle = allocStyle(mCurStyle);
			 mCurStyle->color = mProfile->mFontColor;
			 continue;
		  }
	  }

	  //check the reserved words
	  /*const UTF8 *str = mTextBuffer.getPtr8();
	  str = getNthCodepoint(str, mScanPos);
	  for(U32 rw = 0; rw < getWordCount(str); rw++)
	  {

	   const char* retpos = dStrstr( string, substring );
	   if( retpos )
	   
	      
	   return retpos - string;

	  StringUnit::
	  if(!dStrnicmp(str + 1, "/", 1))

	  //arbitrary text catch-all
	  if(!isWord && !isString && !isLineCommented && !isSelectCommented)
	  {
		  if(mCurStyle->color != ColorI(0,0,0))
		  {
			  //didn't return anything, we're a variable!
			  if(mCurStyle->used)
			     mCurStyle = allocStyle(mCurStyle);
			  mCurStyle->color = ColorI(0,0,0);
		  }
	  }*/

/*textemit:
      textStart = mScanPos;
      idx = 1;
      while(mTextBuffer.getChar(mScanPos+idx) && !isTextTerminator(mTextBuffer.getChar(mScanPos+idx)))
         idx++;
      len = idx;
      mScanPos += idx;
      emitTextToken(textStart, len);
   }
}*/


TSCodeParser::Line* TSCodeParser::getLineFromPosition( S32 position )
{
	for(U32 i=0; i < mLines.size(); i++)
	{
		if(position >= mLines[i].startPos && position <= mLines[i].endPos)
			return &mLines[i];
	}

	return NULL;
}

/// Finds the first object name from the start position
S32 TSCodeParser::findObjectName( S32 startPosition, String &objName)
{
	mScanPos = startPosition;
	Line* l = getLineFromPosition(startPosition);
	if(l == NULL)
		return -1;

	while(l != NULL)
	{
		S32 start = startPosition > l->startPos ? startPosition : l->startPos;
		char* line = (char*)mTextBuffer.createSubstring8(start, l->endPos - start);

		//now, look for 'new'. If we haven't found 'new' in the line, we haven't declared anything.
		S32 pos = scanforword( dStrlwr(line), "new" );

		if(pos != -1)
		{
			//we have a declaration, so parse forward until we find a parenthesis
			S32 parthPos = scanforchar(line, pos+2, '(');

			if(parthPos != -1)
			{
				//found it. Now parse to the closing parinth
				S32 endParthPos = scanforchar(line, pos+2+parthPos+1, ')');

				if(endParthPos != -1)
				{
					//and we've got it!
					objName = (const char*)mTextBuffer.createSubstring8(start+pos+2+parthPos+1, endParthPos);

					return start+pos+2+parthPos+1;
				}
			}
		}
		
		l = getLineFromPosition(l->endPos+1);
	}

	return -1;
}

S32 TSCodeParser::find( const char* find, S32 startPosition )
{
	Line* l = getLineFromPosition(startPosition);
	if(l == NULL)
		return -1;

	while(l != NULL)
	{
		S32 start = startPosition > l->startPos ? startPosition : l->startPos;
		char* line = (char*)mTextBuffer.createSubstring8(start, l->endPos - start);

		S32 pos = scanforword( strlwr(line), strlwr((char*)find) );

		if(pos != -1)
		{
			return pos;
		}

		l = getLineFromPosition(l->endPos+1);
	}

	return -1;
	//S32 lineIdx = getLineFromPosition(startPosition);

	//if(lineIdx == -1)
		//return -1;

	/*for(S32 l = lineIdx; l < mLines.size(); l++)
	{
		S32 start = mLines[l];
	   S32 end = (l == mLines.size() - 1) ? mTextLength : mLines[l+1];

		//get the line
		char* line = (char*)mTextBuffer.createSubstring8(start, end-start);

		S32 pos = scanforword( strlwr(line), strlwr((char*)find) );

		if(pos != -1)
		{
			return pos;
		}
	}*/
}

void TSCodeParser::findAndReplace( const char* find, const char* replace, S32 startPosition )
{
	Line* l = getLineFromPosition(startPosition);
	if(l == NULL)
		return;

	S32 lineAdjust = 0;
	while(l != NULL)
	{
		//Adjust the line info for changes we've made so far
		l->startPos -= lineAdjust;
		l->endPos -= lineAdjust;

		S32 start = startPosition > l->startPos ? startPosition : l->startPos;
		char* line = (char*)mTextBuffer.createSubstring8(start, l->endPos - start);

		S32 pos = scanforword( strlwr(line), strlwr((char*)find) );

		if(pos != -1)
		{
			lineAdjust += strlen(find) - strlen(replace);
			mTextLength -= strlen(find) - strlen(replace);

			mTextBuffer.cut(start+pos, strlen(find));
			mTextBuffer.insert(start+pos, replace);
		}

		l = getLineFromPosition(l->endPos+1);
	}
	//S32 lineIdx = getLineFromPosition(startPosition);

	//if(lineIdx == -1)
		//return;

	/*S32 lineAdjust = 0;

	for(S32 l = lineIdx; l < mLines.size(); l++)
	{
		//If we've made modification to the text, adjust the line offsets
		mLines[l] -= lineAdjust;

		S32 start = mLines[l];
	   S32 end = (l == mLines.size() - 1) ? mTextLength : mLines[l+1];

		//get the line
		char* line = (char*)mTextBuffer.createSubstring8(start, end-start);

		S32 pos = scanforword( strlwr(line), strlwr((char*)find) );

		if(pos != -1)
		{
			lineAdjust += strlen(find) - strlen(replace);
			mTextLength -= strlen(find) - strlen(replace);

			mTextBuffer.cut(start+pos, strlen(find));
			mTextBuffer.insert(start+pos, replace);
		}
	}

	S32 jhiia = 0;*/
}

bool TSCodeParser::loadFile(const char* path)
{
	mTextLength = 0; 

	static char scriptFilenameBuffer[1024];
	Con::expandScriptFilename( scriptFilenameBuffer, sizeof( scriptFilenameBuffer ), path );
	StringTableEntry scriptFileName = StringTable->insert(scriptFilenameBuffer);

	void *data;
   U32 dataSize = 0;
   Torque::FS::ReadFile(scriptFileName, data, dataSize, true);

	const char*	script = (char *)data;

	mTextBuffer.append(script);

	//parse for lines!
	mTextLength = strlen(script);
	S32 charCount = strlen(script);
	S32 curPos = 0;
	while(curPos < charCount)
	{
		const char* line = readLine(curPos);

		S32 numChars = strlen(line);

		Line newLine;

		newLine.startPos = curPos;
		newLine.endPos = curPos + numChars;

		mLines.push_back(newLine);

		curPos += numChars;
	}

	return true;
}

void TSCodeParser::buildObjectList()
{
	S32 startPos = 0;

	//first, we build our list of objects
	//for(U32 i
	//S32 TSCodeParser::findObjectName( S32 startPosition, String &objName)
}

String TSCodeParser::getObjectField( S32 objectPos, String &fieldName)
{
	/*mScanPos = startPosition;
	Line* l = getLineFromPosition(startPosition);
	if(l == NULL)
		return -1;

	while(l != NULL)
	{
		S32 start = startPosition > l->startPos ? startPosition : l->startPos;
		char* line = (char*)mTextBuffer.createSubstring8(start, l->endPos - start);

		//now, look for 'new'. If we haven't found 'new' in the line, we haven't declared anything.
		S32 pos = scanforword( dStrlwr(line), "new" );

		if(pos != -1)
		{
			//we have a declaration, so parse forward until we find a parenthesis
			S32 parthPos = scanforchar(line, pos+2, '(');

			if(parthPos != -1)
			{
				//found it. Now parse to the closing parinth
				S32 endParthPos = scanforchar(line, pos+2+parthPos+1, ')');

				if(endParthPos != -1)
				{
					//and we've got it!
					objName = (const char*)mTextBuffer.createSubstring8(start+pos+2+parthPos+1, endParthPos);

					return start+pos+2+parthPos+1;
				}
			}
		}
		
		l = getLineFromPosition(l->endPos+1);
	}

	return -1;*/
	return "";
}

void TSCodeParser::execute()
{
	Con::evaluate(getCode());
}