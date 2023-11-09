\ ----===< prefix >===-----
c-library sdl_ttf
s" SDL2_ttf" add-lib
\c #include <SDL2/SDL_ttf.h>


\ ----===< int constants >===-----
#2	constant SDL_TTF_MAJOR_VERSION
#20	constant SDL_TTF_MINOR_VERSION
#2	constant SDL_TTF_PATCHLEVEL
#2	constant TTF_MAJOR_VERSION
#20	constant TTF_MINOR_VERSION
#2	constant TTF_PATCHLEVEL
#65279	constant UNICODE_BOM_NATIVE
#65534	constant UNICODE_BOM_SWAPPED
#0	constant TTF_STYLE_NORMAL
#1	constant TTF_STYLE_BOLD
#2	constant TTF_STYLE_ITALIC
#4	constant TTF_STYLE_UNDERLINE
#8	constant TTF_STYLE_STRIKETHROUGH
#0	constant TTF_HINTING_NORMAL
#1	constant TTF_HINTING_LIGHT
#2	constant TTF_HINTING_MONO
#3	constant TTF_HINTING_NONE
#4	constant TTF_HINTING_LIGHT_SUBPIXEL
#0	constant TTF_WRAPPED_ALIGN_LEFT
#1	constant TTF_WRAPPED_ALIGN_CENTER
#2	constant TTF_WRAPPED_ALIGN_RIGHT


\ --------===< enums >===---------
#0	constant TTF_DIRECTION_LTR
#1	constant TTF_DIRECTION_RTL
#2	constant TTF_DIRECTION_TTB
#3	constant TTF_DIRECTION_BTT


\c SDL_Surface * GF_TTF_RenderText_Solid(TTF_Font *font, const char *text, SDL_Color *fg) {
\c     return TTF_RenderText_Solid(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderUTF8_Solid(TTF_Font *font, const char *text, SDL_Color *fg) {
\c     return TTF_RenderUTF8_Solid(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Solid(TTF_Font *font, const Uint16 *text, SDL_Color *fg) {
\c     return TTF_RenderUNICODE_Solid(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderText_Solid_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderText_Solid_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUTF8_Solid_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderUTF8_Solid_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Solid_Wrapped(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderUNICODE_Solid_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderGlyph_Solid(TTF_Font *font, Uint16 ch, SDL_Color *fg) {
\c     return TTF_RenderGlyph_Solid(font, ch, *fg); }

\c SDL_Surface * GF_TTF_RenderGlyph32_Solid(TTF_Font *font, Uint32 ch, SDL_Color *fg) {
\c     return TTF_RenderGlyph32_Solid(font, ch, *fg); }

\c SDL_Surface * GF_TTF_RenderText_Shaded(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderText_Shaded(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderUTF8_Shaded(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderUTF8_Shaded(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Shaded(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderUNICODE_Shaded(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderText_Shaded_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderText_Shaded_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUTF8_Shaded_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderUTF8_Shaded_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Shaded_Wrapped(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderUNICODE_Shaded_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderGlyph_Shaded(TTF_Font *font, Uint16 ch, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderGlyph_Shaded(font, ch, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderGlyph32_Shaded(TTF_Font *font, Uint32 ch, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderGlyph32_Shaded(font, ch, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderText_Blended(TTF_Font *font, const char *text, SDL_Color *fg) {
\c     return TTF_RenderText_Blended(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderUTF8_Blended(TTF_Font *font, const char *text, SDL_Color *fg) {
\c     return TTF_RenderUTF8_Blended(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Blended(TTF_Font *font, const Uint16 *text, SDL_Color *fg) {
\c     return TTF_RenderUNICODE_Blended(font, text, *fg); }

\c SDL_Surface * GF_TTF_RenderText_Blended_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderText_Blended_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUTF8_Blended_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderUTF8_Blended_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUNICODE_Blended_Wrapped(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, Uint32 wrapLength) {
\c     return TTF_RenderUNICODE_Blended_Wrapped(font, text, *fg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderGlyph_Blended(TTF_Font *font, Uint16 ch, SDL_Color *fg) {
\c     return TTF_RenderGlyph_Blended(font, ch, *fg); }

\c SDL_Surface * GF_TTF_RenderGlyph32_Blended(TTF_Font *font, Uint32 ch, SDL_Color *fg) {
\c     return TTF_RenderGlyph32_Blended(font, ch, *fg); }

\c SDL_Surface * GF_TTF_RenderText_LCD(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderText_LCD(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderUTF8_LCD(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderUTF8_LCD(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderUNICODE_LCD(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderUNICODE_LCD(font, text, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderText_LCD_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderText_LCD_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUTF8_LCD_Wrapped(TTF_Font *font, \
\c     const char *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderUTF8_LCD_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderUNICODE_LCD_Wrapped(TTF_Font *font, \
\c     const Uint16 *text, SDL_Color *fg, SDL_Color *bg, Uint32 wrapLength) {
\c     return TTF_RenderUNICODE_LCD_Wrapped(font, text, *fg, *bg, wrapLength); }

\c SDL_Surface * GF_TTF_RenderGlyph_LCD(TTF_Font *font, Uint16 ch, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderGlyph_LCD(font, ch, *fg, *bg); }

\c SDL_Surface * GF_TTF_RenderGlyph32_LCD(TTF_Font *font, Uint32 ch, SDL_Color *fg, SDL_Color *bg) {
\c     return TTF_RenderGlyph32_LCD(font, ch, *fg, *bg); }


\ ------===< functions >===-------
c-function TTF_GetError SDL_GetError  -- a	( -- string )
c-function TTF_ClearError SDL_ClearError  -- void	( -- )
c-function TTF_Linked_Version TTF_Linked_Version  -- a	( -- )
c-function TTF_GetFreeTypeVersion TTF_GetFreeTypeVersion a a a -- void	( major minor patch -- )
c-function TTF_GetHarfBuzzVersion TTF_GetHarfBuzzVersion a a a -- void	( major minor patch -- )
c-function TTF_ByteSwappedUNICODE TTF_ByteSwappedUNICODE n -- void	( swapped -- )
c-function TTF_Init TTF_Init  -- n	( -- )
c-function TTF_OpenFont TTF_OpenFont a n -- a	( file ptsize -- )
c-function TTF_OpenFontIndex TTF_OpenFontIndex a n n -- a	( file ptsize index -- )
c-function TTF_OpenFontRW TTF_OpenFontRW a n n -- a	( src freesrc ptsize -- )
c-function TTF_OpenFontIndexRW TTF_OpenFontIndexRW a n n n -- a	( src freesrc ptsize index -- )
c-function TTF_OpenFontDPI TTF_OpenFontDPI a n n n -- a	( file ptsize hdpi vdpi -- )
c-function TTF_OpenFontIndexDPI TTF_OpenFontIndexDPI a n n n n -- a	( file ptsize index hdpi vdpi -- )
c-function TTF_OpenFontDPIRW TTF_OpenFontDPIRW a n n n n -- a	( src freesrc ptsize hdpi vdpi -- )
c-function TTF_OpenFontIndexDPIRW TTF_OpenFontIndexDPIRW a n n n n n -- a	( src freesrc ptsize index hdpi vdpi -- )
c-function TTF_SetFontSize TTF_SetFontSize a n -- n	( font ptsize -- )
c-function TTF_SetFontSizeDPI TTF_SetFontSizeDPI a n n n -- n	( font ptsize hdpi vdpi -- )
c-function TTF_GetFontStyle TTF_GetFontStyle a -- n	( font -- )
c-function TTF_SetFontStyle TTF_SetFontStyle a n -- void	( font style -- )
c-function TTF_GetFontOutline TTF_GetFontOutline a -- n	( font -- )
c-function TTF_SetFontOutline TTF_SetFontOutline a n -- void	( font outline -- )
c-function TTF_GetFontHinting TTF_GetFontHinting a -- n	( font -- )
c-function TTF_SetFontHinting TTF_SetFontHinting a n -- void	( font hinting -- )
c-function TTF_GetFontWrappedAlign TTF_GetFontWrappedAlign a -- n	( font -- )
c-function TTF_SetFontWrappedAlign TTF_SetFontWrappedAlign a n -- void	( font align -- )
c-function TTF_FontHeight TTF_FontHeight a -- n	( font -- )
c-function TTF_FontAscent TTF_FontAscent a -- n	( font -- )
c-function TTF_FontDescent TTF_FontDescent a -- n	( font -- )
c-function TTF_FontLineSkip TTF_FontLineSkip a -- n	( font -- )
c-function TTF_GetFontKerning TTF_GetFontKerning a -- n	( font -- )
c-function TTF_SetFontKerning TTF_SetFontKerning a n -- void	( font allowed -- )
c-function TTF_FontFaces TTF_FontFaces a -- n	( font -- )
c-function TTF_FontFaceIsFixedWidth TTF_FontFaceIsFixedWidth a -- n	( font -- )
c-function TTF_FontFaceFamilyName TTF_FontFaceFamilyName a -- a	( font -- )
c-function TTF_FontFaceStyleName TTF_FontFaceStyleName a -- a	( font -- )
c-function TTF_GlyphIsProvided TTF_GlyphIsProvided a n -- n	( font ch -- )
c-function TTF_GlyphIsProvided32 TTF_GlyphIsProvided32 a n -- n	( font ch -- )
c-function TTF_GlyphMetrics TTF_GlyphMetrics a n a a a a a -- n	( font ch minx maxx miny maxy advance -- )
c-function TTF_GlyphMetrics32 TTF_GlyphMetrics32 a n a a a a a -- n	( font ch minx maxx miny maxy advance -- )
c-function TTF_SizeText TTF_SizeText a a a a -- n	( font text w h -- )
c-function TTF_SizeUTF8 TTF_SizeUTF8 a a a a -- n	( font text w h -- )
c-function TTF_SizeUNICODE TTF_SizeUNICODE a a a a -- n	( font text w h -- )
c-function TTF_MeasureText TTF_MeasureText a a n a a -- n	( font text measure_width extent count -- )
c-function TTF_MeasureUTF8 TTF_MeasureUTF8 a a n a a -- n	( font text measure_width extent count -- )
c-function TTF_MeasureUNICODE TTF_MeasureUNICODE a a n a a -- n	( font text measure_width extent count -- )
c-function TTF_RenderText_Solid GF_TTF_RenderText_Solid a a a -- a	( font text fg -- )
c-function TTF_RenderUTF8_Solid GF_TTF_RenderUTF8_Solid a a a -- a	( font text fg -- )
c-function TTF_RenderUNICODE_Solid GF_TTF_RenderUNICODE_Solid a a a -- a	( font text fg -- )
c-function TTF_RenderText_Solid_Wrapped GF_TTF_RenderText_Solid_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderUTF8_Solid_Wrapped GF_TTF_RenderUTF8_Solid_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderUNICODE_Solid_Wrapped GF_TTF_RenderUNICODE_Solid_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderGlyph_Solid GF_TTF_RenderGlyph_Solid a n a -- a	( font ch fg -- )
c-function TTF_RenderGlyph32_Solid GF_TTF_RenderGlyph32_Solid a n a -- a	( font ch fg -- )
c-function TTF_RenderText_Shaded GF_TTF_RenderText_Shaded a a a a -- a	( font text fg bg -- )
c-function TTF_RenderUTF8_Shaded GF_TTF_RenderUTF8_Shaded a a a a -- a	( font text fg bg -- )
c-function TTF_RenderUNICODE_Shaded GF_TTF_RenderUNICODE_Shaded a a a a -- a	( font text fg bg -- )
c-function TTF_RenderText_Shaded_Wrapped GF_TTF_RenderText_Shaded_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderUTF8_Shaded_Wrapped GF_TTF_RenderUTF8_Shaded_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderUNICODE_Shaded_Wrapped GF_TTF_RenderUNICODE_Shaded_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderGlyph_Shaded GF_TTF_RenderGlyph_Shaded a n a a -- a	( font ch fg bg -- )
c-function TTF_RenderGlyph32_Shaded GF_TTF_RenderGlyph32_Shaded a n a a -- a	( font ch fg bg -- )
c-function TTF_RenderText_Blended GF_TTF_RenderText_Blended a a a -- a	( font text fg -- )
c-function TTF_RenderUTF8_Blended GF_TTF_RenderUTF8_Blended a a a -- a	( font text fg -- )
c-function TTF_RenderUNICODE_Blended GF_TTF_RenderUNICODE_Blended a a a -- a	( font text fg -- )
c-function TTF_RenderText_Blended_Wrapped GF_TTF_RenderText_Blended_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderUTF8_Blended_Wrapped GF_TTF_RenderUTF8_Blended_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderUNICODE_Blended_Wrapped GF_TTF_RenderUNICODE_Blended_Wrapped a a a n -- a	( font text fg wrapLength -- )
c-function TTF_RenderGlyph_Blended GF_TTF_RenderGlyph_Blended a n a -- a	( font ch fg -- )
c-function TTF_RenderGlyph32_Blended GF_TTF_RenderGlyph32_Blended a n a -- a	( font ch fg -- )
c-function TTF_RenderText_LCD GF_TTF_RenderText_LCD a a a a -- a	( font text fg bg -- )
c-function TTF_RenderUTF8_LCD GF_TTF_RenderUTF8_LCD a a a a -- a	( font text fg bg -- )
c-function TTF_RenderUNICODE_LCD GF_TTF_RenderUNICODE_LCD a a a a -- a	( font text fg bg -- )
c-function TTF_RenderText_LCD_Wrapped GF_TTF_RenderText_LCD_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderUTF8_LCD_Wrapped GF_TTF_RenderUTF8_LCD_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderUNICODE_LCD_Wrapped GF_TTF_RenderUNICODE_LCD_Wrapped a a a a n -- a	( font text fg bg wrapLength -- )
c-function TTF_RenderGlyph_LCD GF_TTF_RenderGlyph_LCD a n a a -- a	( font ch fg bg -- )
c-function TTF_RenderGlyph32_LCD GF_TTF_RenderGlyph32_LCD a n a a -- a	( font ch fg bg -- )
c-function TTF_CloseFont TTF_CloseFont a -- void	( font -- )
c-function TTF_Quit TTF_Quit  -- void	( -- )
c-function TTF_WasInit TTF_WasInit  -- n	( -- )
\ c-function TTF_GetFontKerningSize TTF_GetFontKerningSize a n n -- n	( font prev_index index -- )
c-function TTF_GetFontKerningSizeGlyphs TTF_GetFontKerningSizeGlyphs a n n -- n	( font previous_ch ch -- )
c-function TTF_GetFontKerningSizeGlyphs32 TTF_GetFontKerningSizeGlyphs32 a n n -- n	( font previous_ch ch -- )
c-function TTF_SetFontSDF TTF_SetFontSDF a n -- n	( font on_off -- )
c-function TTF_GetFontSDF TTF_GetFontSDF a -- n	( font -- )
\ c-function TTF_SetDirection TTF_SetDirection n -- n	( direction -- )
\ c-function TTF_SetScript TTF_SetScript n -- n	( script -- )
c-function TTF_SetFontDirection TTF_SetFontDirection a n -- n	( font direction -- )
c-function TTF_SetFontScriptName TTF_SetFontScriptName a a -- n	( font script -- )


\ ----===< postfix >===-----
end-c-library
