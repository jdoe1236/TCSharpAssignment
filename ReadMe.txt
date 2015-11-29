Database
--------
Database is already built and db files are inside App_Data folder of web application



Build
-----
1. Open Solution in Visual Studio 2012 or higher. And 
2. Set mail client information in web.config under "<system.net>...<mailSettings>"
3. Select web project in Solution Explorer and press F5
   Or
   Build > Build Solution.



Webservice Test Client App
--------------------------
1. Make sure website is running
2. Open App.Config and make sure the endpoint address(host) is correct for webservice.
3. Update sender email(emailAddressForResult) in Program.cs. Must be registered user/email.
4. Rebuild the app



Feedback
--------
Sending 10 raw pdf files(Max) to email may not be good, a good option would be to put all 
search result in a zip archive limiting it with zip file size, not with number of files and 
send it to the request generater's email.

Using Linq-SQL is way easy for developers and is not bad for low traffic websites. 
But for high traffic websites, the ASP.net app must be highly optimized and I would avoid LINQ-SQL for it.

Wink is not good enough for capturing videos and not maintained. Since it only creates video of screen, 
there are many alternatives. I tried Wink as it was suggested, but I would avoid it. It looks very old.


Feedback 2
----------
It is my feedback and I'm not criticizing. 
The description of assignment must be simple so it doesn't sounds very big or complicated project. 
Only few things could have been used. Like what features will be required in assignment and what files to upload. 
Just that, please make it easier to understand. 
It shouldn't have preconditions or functional specifications or others. 
Because they are already covered in rest of description.
Also if a programmer is applying for a job he would already know the preconditions. 
Preconditions and others may be required in other assignments but the one I got, it doesn't. 
Anyway, again it's just my feedback about improving the assignment or any other assignment. 
I can write assignment details if you are interested. Thank you :)


About Design.Doc
----------------
I do not have proper tools to create UML designs, I usually draw them on paper with pencil for very complicated cases.
But if I have to on software I would avoid it, I love to code and design for hours. 
But UML softwares, I just avoid them. They takes too much time for nothing. Just my thoughts. :)
Again but, I can draw on paper which is faster and saves time.




