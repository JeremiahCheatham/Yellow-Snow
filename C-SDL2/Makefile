CC				?= gcc
CFLAGS_BASE		= `pkg-config --cflags sdl2 SDL2_image SDL2_mixer SDL2_ttf` -std=c99
CFLAGS_RELEASE	= -O2
CFLAGS_DEV		= -O0 -ggdb3 -Wall -Wextra -Wwrite-strings -Werror -Wunused -Wuninitialized \
                 -Wconversion -Wshadow -Wformat -Wmissing-prototypes -Wmissing-declarations \
				 -Wfloat-equal -Wsign-compare -fsanitize=address -fsanitize-address-use-after-scope
CFLAGS			= $(CFLAGS_BASE) $(CFLAGS_DEV)
LDLIBS_BASE		= `pkg-config --libs sdl2 SDL2_image SDL2_mixer SDL2_ttf` -lm
LDLIBS_DEV      = -fsanitize=address -fsanitize-address-use-after-scope
LDLIBS          = $(LDLIBS_BASE) $(LDLIBS_DEV)
TARGET			= yellow-snow

SRCS			= $(wildcard *.c)
BUILD_DIR 		= .build
OBJS    		= $(addprefix $(BUILD_DIR)/, $(SRCS:.c=.o))

$(BUILD_DIR):
	mkdir -p $(BUILD_DIR)

$(BUILD_DIR)/%.o: %.c %.h | $(BUILD_DIR)
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $(LDLIBS) $^ -o $@

.PHONY: all release run clean

all: $(TARGET)

release: CFLAGS = $(CFLAGS_BASE) $(CFLAGS_RELEASE)
release: LDLIBS = $(LDLIBS_BASE)
release: all

run: $(TARGET)
	./$<

clean:
	$(RM) -r $(BUILD_DIR) $(TARGET)
