# DUS-Pack

--DUS-Pack Alpha--


----------------------------

DUS (devunion script) package is a Unity C# script that allows you to save a lot of time by including scripts that has a lot of general use cases.

----------------------------

Installation Guide:

1. Download the zip file

2. Extract the zip 

3. Drag and drop the extracted folder(or only the contents of it) to any folder in your project

4. Drag and drop the script on any gameobject in your scene

----------------------------

Call methods:

OnRuntime: execute the operation once on Start();

ExternalCall: waits for ExternalCall() function to recieve an external call to execute the operation;

Tick: runs the operation once per every frame (similar to Update function);

Note that call method cannot be changed during runtime!

----------------------------

Guidelines:

"Use The 'ExternalCall' To Call The Operation From Another Script, You Can Use This Function For Things Like OnTriggerEnter(), OnCOllisionEnter(), RayCastHit, ETC..., how to use:

1. create a script and put it on any object(you can put it on 'DUS-General' As Well),

2.create a variable with the type "DUS_General" with the name "dus_General",

3.type 'dus_General.ExternalCall();' where ever you want to execute the DUS operation(if you are using the FindComponent Operation, You should call the function ComponentCall() instead which returns a variable with the type "Component", if you want to get a specific component like 'BoxCollider', you should write: boxCollider = dus_General.ComponentCall() as BoxCollider).


----------------------------
