# **FCC Practice Exam Generator**

![Project Status: Inactive – The project has reached a stable, usable state but is no longer being actively developed; support/maintenance will be provided as time allows.](http://www.repostatus.org/badges/latest/inactive.svg)
[![lifecycle](https://img.shields.io/badge/lifecycle-stable-green.svg)](https://www.tidyverse.org/lifecycle/#stable)

## UPDATE!

I have included the new question pool for the Amateur Extra exam that goes active July 1, 2024. The database is named fcc_exam_data - new Extra questions July 2024.db. Rename it just "fcc_exam_data" for it to work with the generator program. First rename the old one, THEN rename the new one. If there is notice of significant changes in the final version of the pool, I'll update the db.

I have also rerun the apps on the latest update to the General License Pool which was updated and published March 6, 2024. Both databases have this update.

## **Introduction**

I built these three applications so I could practice up for the three FCC exams (Technician, General, and Amateur Extra) for the Radio Amateur Service license (Ham Radio). I recently updated them and parsed in the latest exam pools. The FCC kindly gives you documents containing every exam question. The only problem is that they never proof read them and so they are a disaster for parsing. I had to invent all sorts of tricks and workarounds to get the questions into the database for the exam generator to use. Just now I also wrote a clean-up program to do some brute force clean-ups of the more obvious screw-ups. After you run it you may find some issues you'll have to hand cull from the source.

Keep and any out for the infamous double tilde "~~". You'll have to do a manual find/replace in your favorite text editor. Replace it with a carriage-return, aka "\r\n".

## **About the projects**

This project contains three programs: the text question pool document cleaner, the text question pool parser, and the practice exam generator. I am uploading a source file folder containing a Visual Studio 2019 solution which contains the three projects. I've clipped off all the stuff below the source code folder level except the properties folder, as you don't need those things to work with the solution initially and it will keep the download size reasonable. You can pull this solution into VS2019 or VS2022 and then compile. Note that I have set the projects to use .Net 4.7.2 (the latest as of this time). Make sure you have it installed.

In the projects I used regular expressions (the Regex class). I needed a couple helper programs to do that. Instead of uploading them to this repository I am going to give you the URL's where to find them so that you can always have the latest versions.

The first one is .Net Regular Expression Designer: <https://download.cnet.com/NET-Regular-Expression-Designer/3000-10250_4-75968853.html>

The second is a grep program: <https://sourceforge.net/projects/grepwin/>

I also used a very nice PDF to text application that really works: <https://www.4dots-software.com/free-pdf-to-text-converter/> My programs use plain text files as source and the early pool texts were in PDF form. The newest Amateur Extra pool from NCVEC is in mulitple formats including MS Word.

The other thing I used is SQLite database server. It is a very small and light weight and free application suitable for use in apps like this. Originally I wrote the apps to use MS SQL Server 2008. A while later I updated them to use MySQL server as it is free and freely available. A couple years later (present time) I was looking over the apps and decided to update them and rework some of the code. While MySQL is a fantastic DB server, it is way too much for a couple of apps like this. SQLite has come along and matured to the point it is stable and has interfaces for Visual Studio so I rewrote the DB interfaces to use it. Word of caution: I tried downloading from the source web site and tried installing it to the solution but it never seemed to work well. Instead I went to the VS2019 Nuget Manager and brought down the packages for SQLite and System.Data.SQLite. You'll wind up with some extraneous downloads in the packages but don't worry about it as they will not be in the compiled output.

The first helper I used (a lot!) is DB Browser for SQLite: [https://sqlitebrowser.org](https://sqlitebrowser.org/)

The second is SQLiteStudio: <https://https://sqlitestudio.pl/>

If you are not familiar with these helper apps please read up their documentation. There's little annoying gotchas like SQLite can't drop columns. There's a work around for it but you have to read. I have already created the database file and tables for you so you don't need to but if it gets blown away you can easily manually create it. I have included the SQLite FCC exam database create.sql file to use for that. Just open it into the sql window and execute it. You do have to create the database file itself manually but the tables and columns can be created from the SQLite FCC exam database create.sql file.


## License

FCC Practice Exam Generator project is licensed under GNU GENERAL PUBLIC LICENSE Version 3.

## Contribution

To report an issue use the GitHub issue tracker. Please provide as much information as you can.
Contributions are always welcome. Open an issue to contact me. The preferred method of contribution is through a github pull request. 


## **What's next**

After I get this project settled down into GitHub I will move on to my other, similar project for the General Radio Operator License, the new version of the old First Class Radiotelephone license. I'm going to write a supervisory application for my Z-Wave automation modules and mount it as a Windows Service. That should keep me busy for a while. Once the dust settles on that I'm headed back into machine learning. I spent a year researching all the Ph.D papers I could find and then learned Python and a dozen API's like scikit_learn. I've gotten some decent results programmatically but I was getting burn-out so I moved to these projects to clear my head. I am now ready to get into some fuzzy math architecture which apparently has been improving results on time series data -- the holy grail of statistics and machine learning. The other interesting architecture is reservoir ensembles mated up with both regression and classification ANN's.
