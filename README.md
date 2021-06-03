# DUS-Pack

--DUS-Pack Alpha--

Guidelines:

"Use The 'ExternalCall' To Call The Operation From Another Script, You Can Use This Function For Things Like OnTriggerEnter(), OnCOllisionEnter(), RayCastHit, ETC..., how to use:

1. create a script and put it on any object(you can put it on 'DUS-General' As Well),

2.create a variable with the type "DUS_General" with the name "dus_General",

3.type 'dus_General.ExternalCall();' where ever you want to execute the DUS operation(if you are using the FindComponent Operation, You should call the function ComponentCall() instead which returns a variable with the type "Component").

"
