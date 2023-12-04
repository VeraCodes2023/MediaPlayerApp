# Media Player Application

Build a media player application that demonstrates advanced topics in C# programming, including SOLID principles, Clean architecture, Factory pattern, Singleton pattern, Observer pattern, object lifetime, and thread safety.

## Basic features

The media player application is a robust software which contains collections of different media files and users. Each user could create their own playtracks and perform other actions on the media file in their playtracks. One user can have multiple playtracks. Application should not have identical users.

- Only Admins of the application should be able to add, remove, update, delete all the files and users in the application.

- Users should be able to manage their playtracks, including adding, removing, play, pause, stop the media files.
- Media files can be further adjusted while playing:
    - Videos can change volume, brightness (can simply use `int` or `string`)
    - Audios can change volume, sound effect (can simply use `int` or `string`)
- Handle potential errors and exceptions gracefully, providing meaningful error messages to the user.

## Advanced (optional) features

- Display the current status of the certain playtracks (such as the total media files and playtrack owner) and status of certain media file in that playtrack, such as information, the playing status, current position (if on playing) and duration.
- Design a user-friendly command-line interface that allows users to navigate and interact with the application. Provide clear instructions and feedback to guide users through different operations.

## Requirement:

- Design a solid and clean architecture for the media player application.

## Test
![Alt text](image-2.png)