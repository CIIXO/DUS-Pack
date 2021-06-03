# DUS-Pack

--DUS-Pack Alpha--


----------------------------

DUS (DEVUNION SCRIPT) PACKAGE IS A UNITY C# SCRIPT PACKAGE THAT ALLOWS YOU TO SAVE A LOT OF TIME BY INCLUDING SCRIPTS THAT HAS A LOT OF GENERAL USECASES.

----------------------------

INSTALLATION GUIDE:

1.DOWNLOAD THE ZIP FILE

2.EXTRACT THE ZIP 

3.DRAG AND DROP THE EXTRACTED FOLDER(OR ONLY THE CONTENTS OF IT) TO ANY FOLDER IN YOUR PROJECT

4.DRAG AND DROP THE SCRIPT ON ANY GAMEOBJECT IN YOUR SCENE

----------------------------

CALL METHODS:

ONRUNTIME: EXECUTE THE OPERATION ONCE ON START();

EXTERNALCALL: WAITS FOR ExternalCall() FUNCTION TO RECIEVE AN EXTERNAL CALL TO EXECUTE THE OPERATION;

TICK: RUNS THE OPERATION ONCE PER EVERY FRAME (SIMILAR TO UPDATE FUNCTION);

NOTE THAT CALL METHOD CANNOT BE CHANGED DURING RUNTIME!

----------------------------

Guidelines:

"Use The 'ExternalCall' To Call The Operation From Another Script, You Can Use This Function For Things Like OnTriggerEnter(), OnCOllisionEnter(), RayCastHit, ETC..., how to use:

1. create a script and put it on any object(you can put it on 'DUS-General' As Well),

2.create a variable with the type "DUS_General" with the name "dus_General",

3.type 'dus_General.ExternalCall();' where ever you want to execute the DUS operation(if you are using the FindComponent Operation, You should call the function ComponentCall() instead which returns a variable with the type "Component").


----------------------------
