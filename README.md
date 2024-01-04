In this project I use identity in asp.net core6 with clean architected 
In this architect i have three layers likes Web,Core,DataLayer
In DataLayer we have context Folder(in context we coonect to dataBase) and Entities Folder(in Entities we have models database) but in this project i didn't use ORM and
I just made Static data instead of dataBase.
and next layer is Core , In Core we have DTOs Folder(viewModel models) and Utilities Folder(in Utitlities we have Utility classes foe example FixTex Class (in FixTex we have one method 
For Trim And tolower email for check email)) and another folder is Services Folder(in folder we work by Repository) 
And the Last layer is Web , I write this Layer by MVC(model,View,Controller) but i didn't need model but maybe you need model folder in web depend on your busines and mentia :)
In my project , you can login with identity but i did't use package identity microsoft sooo you didn't need install specially nuget package and you can read authentication and authorize
code in program file ...
and by [Authorize] atterbuit on top of contoller you can controll authentication client (if you have another rolles [Authorize("your role")])
but you should set Cliam for example token or name etc and in this project i use two way you can set Claim First way defualt Claim with Specified name and you didn't have
your mential names and the second way you can use claim and you set name :)
