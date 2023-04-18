CC      = g++
CFLAGS  != pkg-config --cflags sdl2 SDL2_image SDL2_ttf SDL2_mixer fmt
CFLAGS  += -std=c++20 -ggdb3 -Wall -Wextra -Wwrite-strings
LDLIBS  != pkg-config --libs sdl2 SDL2_image SDL2_ttf SDL2_mixer fmt
TARGET  = yellow-snow

SRCS    = $(wildcard *.cpp)
OBJS    = $(SRCS:.cpp=.o)

.PHONY: all
all: $(TARGET)

%.o: %.cpp %.h
	$(CC) $(CFLAGS) -c $< -o $@

$(TARGET): $(OBJS)
	$(CC) $(LDLIBS) $^ -o $@

.PHONY: clean
clean:
	$(RM) $(OBJS) $(TARGET)
