int PUERTO = 12345;
import processing.video.*;
Movie video;
Movie video2;

String estado;

Receptor receptor; 

void setup(){
  
  size(800, 600);
  setupOSC(PUERTO);
   // inicalización

  estado = "primervideo";
  receptor = new Receptor();
  video = new Movie(this, "ejemplo1.mov");
  video.loop();
  
  
  video2 = new Movie(this, "ejemplo2.mov");
  video2.loop();
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
  }
  
  
  if (estado.equals ("primervideo")) {
  image(video,0,0);
  }
  
  else if (estado.equals ("segundovideo") ) {
  image(video2,0,0);
  }
  
  
}





void movieEvent(Movie video){
 video.read(); 
 
}
