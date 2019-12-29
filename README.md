# Bandcamp Online Player
[Download](https://github.com/LaineZ/BandcampOnlinePlayer/releases/download/alpha-0.2/Player.zip)
A simple client for bandcamp.com that's allows listing albums from main tag page much easier and provides features like play queue, shuffle mode, low memory usage rather than browser, etc.

**WARNING:** This a alpha version, breakable changes are **inevitable**
## Features
* Audio playback from site in mp3 128k quality
* Playback control: seek, pause, next, prev, volume ...
* Play queue: add/remove album tracks
* Album explorer: allows to explore albums in specified tag
* Album artwork viewer and downloader
* AND MUCH MORE
* Stream mode - adds all tracks in tag category and plays them
## Screenshots
![Screenshot1](https://i.imgur.com/Kx2Etvm.png)
![Screenshot2](https://i.imgur.com/ssbaywa.png)
## Screenshots (current state on Linux)
![ScreenshotFail](https://i.imgur.com/ryOIVdO.png)

## Building (Windows)
Clone repository and open .sln file in Visual Studio with .NET Workload

## Building (Linux)
In this moment linux version is very limited and **cannot** play audio

1. Install Mono and MonoDevelop and open .sln file in MonoDevelop
2. To fix all errors go in all errored .resx files and remove icons. Icons looks like this:
``` 
<data name="$this.Icon" type="System.Resources.ResXFileRef, System.Windows.Forms">
	<value>Resources\$this.Icon.ico;System.Drawing.Icon, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</value>
</data>
```
3. Click run button
