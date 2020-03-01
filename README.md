# Bandcamp Online Player
[Download (Win)](https://github.com/LaineZ/BandcampOnlinePlayer/releases/download/alpha-0.5/Player-Win.zip)
[Download (Linux)](https://github.com/LaineZ/bc_rs)

A simple client for bandcamp.com that's allows listing albums from main tag page much easier and provides features like play queue, shuffle mode, low memory usage rather than browser, etc.

**WARNING:** This a alpha version, breakable changes are **inevitable**
## Features
* Audio playback from site in mp3 128k quality
* Playback control: seek, pause, next, prev, volume ...
* Play queue: add/remove album tracks
* Album explorer: allows to explore albums in specified tag
* Album artwork viewer and downloader
* Stream mode - adds all tracks in tag category and plays them
* Search in albums in category or global search aroud website
* Playlist saving feature
* **AND MUCH MORE**
## Screenshots
![Screenshot1](https://i.imgur.com/WkLJkvg.png)
![Audio now works via jack](https://i.imgur.com/DY17dBO.png)

## Building (Windows)
Clone repository and open .sln file in Visual Studio with .NET Workload

## Building (Linux)
In this moment linux version is very buggy


1. Install Mono and MonoDevelop and open .sln file in MonoDevelop
2. Install JACK, FFmpeg, libjack-dev
	```
	Debian/Ubuntu
	sudo apt install ffmpeg qjackctl libjack-dev
	```
3. To fix all errors go in all errored .resx files and remove icons. Icons looks like this:
``` 
<data name="$this.Icon" type="System.Resources.ResXFileRef, System.Windows.Forms">
	<value>Resources\$this.Icon.ico;System.Drawing.Icon, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a</value>
</data>
```
4. Click run button
