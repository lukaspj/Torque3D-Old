//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

#ifndef _FSTINYXML_H_
#define _FSTINYXML_H_


#ifndef TINYXML_INCLUDED
#include "tinyXML/tinyxml.h"
#endif

#ifndef _FILESTREAM_H_
#include "core/stream/fileStream.h"
#endif

class fsTiXmlDocument : public TiXmlDocument
{
public:
   bool LoadFile( FileStream &stream, TiXmlEncoding encoding = TIXML_DEFAULT_ENCODING );
   bool SaveFile( FileStream &stream );
   void Print( FileStream& stream, int depth );
};

class fsTiXmlAttribute : public TiXmlAttribute
{
public:
   void Print( FileStream& stream, int depth, TIXML_STRING* str = 0 );
};

class fsTiXmlDeclaration : public TiXmlDeclaration
{
public:
   void Print( FileStream& stream, int depth, TIXML_STRING* str = 0 );
};

#endif //_FSTINYXML_H_