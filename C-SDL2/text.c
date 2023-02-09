#include "text.h"


enum Errors text_create(struct Text *text, SDL_Renderer *rend) {
    text->rend = rend;
    text->color = (SDL_Color) FONT_COLOR;
    text->rect.x = 10;
    text->rect.y = 10;
    text->score = 0;

    text->font = TTF_OpenFont(FONT_NAME, FONT_SIZE);
    if (!text->font)
        return ERROR_TTF;

    enum Errors rvalue = text_update(text);
    if (rvalue)
        return rvalue;

    return 0;
}


enum Errors text_update(struct Text *text) {
    if (text->image)
        SDL_DestroyTexture(text->image);
    
    int len = snprintf(NULL, 0, "Score: %d", text->score);
    char new_text[len + 1];
    snprintf(new_text, len + 1, "Score: %d", text->score);

    SDL_Surface *surf = TTF_RenderText_Blended(text->font, new_text, text->color);
    if (!surf)
        return ERROR_SURF;

    text->image = SDL_CreateTextureFromSurface(text->rend, surf);
    if (!text->image)
        return ERROR_TEXT;

    SDL_FreeSurface(surf);

    // Get a rect from the original image.
    if (SDL_QueryTexture(text->image, NULL, NULL, &text->rect.w, &text->rect.h))
        return ERROR_QTEX;
    
    return 0;
}


enum Errors text_draw(struct Text *text) {
    if ( SDL_RenderCopy(text->rend, text->image, NULL, &text->rect))
        return ERROR_COPY;

    return 0;
}
