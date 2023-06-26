# Entornos_virtuales_3D_para_el_estudio_electrofisiologico_de_la_memoria_en_ratones
Código de Unity y Arduino implementado en el sistema de laberintos virtuales para la evaluación electrofisiológica de la memoria y ansiedad en ratones.

En el presente repositorio se encuentra el código de Unity (C#) y de Arduino (C++) que se ha creado e implementado para lograr el correcto funcionamiento de los distintos elementos y funciones que componen los laberintos. De esta forma, se podrá cumplir con los objetivos del proyecto.

El código se ha organizado en diferentes carpetas para facilitar su localización y visualización. Encontramos tres carpetas:

Arduino_Code: contiene el código implementado en Arduino para el control del movimiento por los laberintos de Unity mediante el rotary encoder modeule y la activación del movimiento del stepper motor.

Axiety: contiene el código que meueve al "Player" por el laberinto Light-Dark Box mediante un rotary encoder gracias a la conexión serial con Arduino. Addemás, almacena los datos de tiempo, posición y sector (Dark Sectorn y Light Sectorn) en el que se encuentra el "Player".

Memory_Evaluation: Contiene tres carpetas correspondientes a los tres modelos laberintos desarrolaldos para la evaluación de la memoria en ratones. Cada carpeta incluye el código "MoveChacater" modificado para cada modelo de laberinto. Además, la carpeta "Y_Model" contiene un ejemplo del código implementado para la animación de una de las puertas presentes en el laberinto. El código empleado para las demás puertas es idéntico a este, pero modificando la puerta que se activa.

Por último, aparecen tres ficheros fuera de las carpetas, estos son "CameraLook.cs", "PlayerMovement.cs" y "Teletransporte.cs". Estos contienen código presente en los cuatro modelos de laberintos.

CameraLook: Control del movimiento de la cámara. 

PlayerMovement: Control manual del movimiento del "Player"  mediante el teclado y el mouse. Se ha implementado para comprobar de forma sencilla el funcionemiento de las diferentes partes del laberinto. Posteriormemte, este código se ha desactivado y el control del movimiento se realiza mediante el rotary encoder.

Teletransporte: Reinicia la posición del "Player" a una posición determinada del laberinto cuando se entra en contacto con el onjeto (trigger) que contiene asignado este script.
