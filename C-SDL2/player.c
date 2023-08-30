#include "player.h"

bool player_new(struct Player **player, SDL_Renderer *renderer, SDL_Texture *image) {
    *player = calloc(1, sizeof(struct Player));
    if (!*player) {
        fprintf(stderr, "Error in calloc of player!\n");
        return true;
    }
    struct Player *p = *player;

    p->renderer = renderer;
    p->image = image;

    if (SDL_QueryTexture(p->image, NULL, NULL, &p->rect.w, &p->rect.h)) {
        fprintf(stderr, "Error while querying texture: %s\n", SDL_GetError());
        return true;
    }
    
    p->x_pos = (double)(WINDOW_WIDTH - p->rect.w) / 2;
    p->rect.x = (int)p->x_pos;
    p->rect.y = 377;
    p->speed = 300;
    p->top_offset = 10;
    p->left_offset = 47;
    p->right_offset = 43;
    p->flip = SDL_FLIP_HORIZONTAL;
    p->keystate = SDL_GetKeyboardState(NULL);

    return false;
}

void player_free(struct Player **player) {
    if (*player) {
        (*player)->image = NULL;
        (*player)->renderer = NULL;
        (*player)->keystate = NULL;
        free(*player);
        *player = NULL;
    } 
}

int player_left(struct Player *p) {
    return p->rect.x + p->left_offset;
}

int player_right(struct Player *p) {
    return p->rect.x + p->rect.w - p->right_offset;
}

int player_top(struct Player *p) {
    return p->rect.y + p->top_offset;
}

void player_update(struct Player *p, double dt) {
    if (p->keystate[SDL_SCANCODE_LEFT]) {
        p->x_pos -= p->speed * dt;
        if (p->x_pos + p->left_offset < 0) {
            p->x_pos = -p->left_offset;
        }
        p->rect.x = (int)(p->x_pos + 0.5);
        p->flip = SDL_FLIP_HORIZONTAL;
    }
    if (p->keystate[SDL_SCANCODE_RIGHT] ) {
        p->x_pos += p->speed * dt;
        if (p->x_pos + p->rect.w - p->right_offset > WINDOW_WIDTH) {
            p->x_pos = WINDOW_WIDTH + p->right_offset - p->rect.w;
        }
        p->rect.x = (int)(p->x_pos + 0.5);
        p->flip = SDL_FLIP_NONE;
    }
}

bool player_draw(struct Player *p) {
    if (SDL_RenderCopyEx(p->renderer, p->image, NULL, &p->rect, 0, NULL, p->flip)) {
        fprintf(stderr, "Error while rendering texture: %s\n", SDL_GetError());
        return true;
    }

    return false;
}