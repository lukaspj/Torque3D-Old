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

#include "fsTinyXml.h"

bool fsTiXmlDocument::LoadFile( FileStream &stream, TiXmlEncoding encoding )
{
    // Delete the existing data:
    Clear();
    //TODO: Can't clear location, investigate if this gives issues.
    //doc.location.Clear();

    // Get the file size, so we can pre-allocate the string. HUGE speed impact.
    long length = stream.getStreamSize();

    // Strange case, but good to handle up front.
    if ( length <= 0 )
    {
        SetError( TiXmlDocument::TIXML_ERROR_DOCUMENT_EMPTY, 0, 0, TIXML_ENCODING_UNKNOWN );
        return false;
    }

    // Subtle bug here. TinyXml did use fgets. But from the XML spec:
    // 2.11 End-of-Line Handling
    // <snip>
    // <quote>
    // ...the XML processor MUST behave as if it normalized all line breaks in external 
    // parsed entities (including the document entity) on input, before parsing, by translating 
    // both the two-character sequence #xD #xA and any #xD that is not followed by #xA to 
    // a single #xA character.
    // </quote>
    //
    // It is not clear fgets does that, and certainly isn't clear it works cross platform. 
    // Generally, you expect fgets to translate from the convention of the OS to the c/unix
    // convention, and not work generally.

    /*
    while( fgets( buf, sizeof(buf), file ) )
    {
        data += buf;
    }
    */

    char* buf = new char[ length+1 ];
    buf[0] = 0;

    if ( !stream.read( length, buf ) ) {
        delete [] buf;
        SetError( TiXmlDocument::TIXML_ERROR_OPENING_FILE, 0, 0, TIXML_ENCODING_UNKNOWN );
        return false;
    }

    // Process the buffer in place to normalize new lines. (See comment above.)
    // Copies from the 'p' to 'q' pointer, where p can advance faster if
    // a newline-carriage return is hit.
    //
    // Wikipedia:
    // Systems based on ASCII or a compatible character set use either LF  (Line feed, '\n', 0x0A, 10 in decimal) or 
    // CR (Carriage return, '\r', 0x0D, 13 in decimal) individually, or CR followed by LF (CR+LF, 0x0D 0x0A)...
    //                * LF:    Multics, Unix and Unix-like systems (GNU/Linux, AIX, Xenix, Mac OS X, FreeBSD, etc.), BeOS, Amiga, RISC OS, and others
    //                * CR+LF: DEC RT-11 and most other early non-Unix, non-IBM OSes, CP/M, MP/M, DOS, OS/2, Microsoft Windows, Symbian OS
    //                * CR:    Commodore 8-bit machines, Apple II family, Mac OS up to version 9 and OS-9

    const char* p = buf;        // the read head
    char* q = buf;                        // the write head
    const char CR = 0x0d;
    const char LF = 0x0a;

    buf[length] = 0;
    while( *p ) {
        assert( p < (buf+length) );
        assert( q <= (buf+length) );
        assert( q <= p );

        if ( *p == CR ) {
            *q++ = LF;
            p++;
            if ( *p == LF ) {                // check for CR+LF (and skip LF)
                p++;
            }
        }
        else {
            *q++ = *p++;
        }
    }
    assert( q <= (buf+length) );
    *q = 0;

    Parse( buf, 0, encoding );

    delete [] buf;
    return !Error();
}

bool fsTiXmlDocument::SaveFile( FileStream &stream )
{
    /*if ( TiXmlDocument::useMicrosoftBOM ) 
    {
        const unsigned char TIXML_UTF_LEAD_0 = 0xefU;
        const unsigned char TIXML_UTF_LEAD_1 = 0xbbU;
        const unsigned char TIXML_UTF_LEAD_2 = 0xbfU;

        stream.write( TIXML_UTF_LEAD_0 );
        stream.write( TIXML_UTF_LEAD_1 );
        stream.write( TIXML_UTF_LEAD_2 );
    }*/
    Print( stream, 0 );
    return true;
}

void fsTiXmlDocument::Print( FileStream& stream, int depth )
{
    for ( const TiXmlNode* node=FirstChild(); node; node=node->NextSibling() )
    {
        node->Print( stream, depth );
        stream.writeText( "\n" );
    }
}

void fsTiXmlAttribute::Print( FileStream& stream, int depth, TIXML_STRING* str )
{
	TIXML_STRING n, v;

   TiXmlString value = TiXmlString(Value());

   EncodeString( NameTStr(), &n );
   EncodeString( value, &v );

    for ( int i=0; i< depth; i++ ) {
        stream.writeText( "    " );
    }

	if (value.find ('\"') == TIXML_STRING::npos) {
        const char* pValue = v.c_str();
        char buffer[4096];
        const S32 length = dSprintf(buffer, sizeof(buffer), "%s=\"%s\"", n.c_str(), pValue);
        stream.write(length, buffer);
        if ( str ) {
            (*str) += n; (*str) += "=\""; (*str) += v; (*str) += "\"";
        }
    }
    else {
        char buffer[4096];
        const S32 length = dSprintf(buffer, sizeof(buffer), "%s='%s'", n.c_str(), v.c_str());
        stream.write(length, buffer);
        if ( str ) {
            (*str) += n; (*str) += "='"; (*str) += v; (*str) += "'";
        }
    }
}