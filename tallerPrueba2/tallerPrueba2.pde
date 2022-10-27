import processing.video.*;
Movie video;
int PUERTO = 12345;
Receptor receptor; // declaración del objeto adminstrador de mensajes

void setup(){
  
  size(800, 600);
  
  video = new Movie(this,"ejemplo1.mov");
  video.loop();
  setupOSC(PUERTO);
  receptor = new Receptor(); // inicalización
 
}


void movieEvent(Movie video){
 video.read(); 
}




void draw(){
  
  background(255);
  
  receptor.actualizar(mensajes); // el recpetor busca la información de los objeto entrantes en los mensajes OSC

  receptor.dibujarObjetos(width, height);
  
  
  for (Objeto o : receptor.objetos){
  
    if(o.entro){ // evento de entrada de cada objeto
      println( "--> entro objeto: " + o.id);
    }
  }
  for (Objeto o : receptor.objetos){
  
    if(o.salio){ // evento de entrada de cada objeto
      println( "<-- entro salio: " + o.id);
    }
       fill(255,0,0);
      rect(0,0,height, width);
      image(video,0,0);
  }
 
}
