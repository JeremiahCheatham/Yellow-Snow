TARGET			= yellow-snow
BUILD_DIR		= .build

CC				= gcc
CFLAGS_BASE		= -std=c99
CFLAGS_RELEASE	= -O2

ifeq ($(OS),Windows_NT)
	CFLAGS_DEV	= -O0 -ggdb3 -Wall -Wextra -Wwrite-strings -Werror -Wunused -Wuninitialized \
				-Wconversion -Wshadow -Wformat -Wmissing-prototypes -Wmissing-declarations \
				-Wfloat-equal -Wsign-compare
	LDLIBS_BASE	= -lSDL2 -lSDL2_image -lSDL2_ttf -lSDL2_mixer
	LDLIBS_DEV	=
	CLEAN		= del /f $(TARGET).exe & if exist $(BUILD_DIR) rmdir /s /q $(BUILD_DIR)
else
	CFLAGS_DEV	= -O0 -ggdb3 -Wall -Wextra -Wwrite-strings -Werror -Wunused -Wuninitialized \
				-Wconversion -Wshadow -Wformat -Wmissing-prototypes -Wmissing-declarations \
				-Wfloat-equal -Wsign-compare -fsanitize=address -fsanitize-address-use-after-scope
	LDLIBS_BASE	= `pkg-config --libs sdl2 SDL2_image SDL2_ttf SDL2_mixer`
	LDLIBS_DEV	= -fsanitize=address -fsanitize-address-use-after-scope
	CLEAN		= $(RM) -r $(BUILD_DIR) $(TARGET)
endif

CFLAGS			= $(CFLAGS_BASE) $(CFLAGS_DEV)
LDLIBS			= $(LDLIBS_BASE) $(LDLIBS_DEV)
SRCS			= $(wildcard *.c)
OBJS			= $(addprefix $(BUILD_DIR)/, $(SRCS:.c=.o))

$(BUILD_DIR):
	mkdir $(BUILD_DIR)

$(BUILD_DIR)/%.o: %.c %.h | $(BUILD_DIR)
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $^ -o $@ $(LDLIBS)

.PHONY: all release run clean

all: $(TARGET)

release: CFLAGS	= $(CFLAGS_BASE) $(CFLAGS_RELEASE)
release: LDLIBS	= $(LDLIBS_BASE)
release: all

run: $(TARGET)
	./$<

clean:
	$(CLEAN)
