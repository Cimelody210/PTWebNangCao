var vc3d_style = function(selectedName, params){
    this.selectro = $(selectedName);
    this.imagePath =  params.imgaePath;
    this.ImgaeExtension = params.imgageExtension ||"png";
    this.isMOving = false;
    this.currentX = 0;
    this.currentImage = 1;
    function assiangOperation(){
        selectro.mousedown(function(target){
            isMOving = true;
            currentX = target.pageX - this.offsetLeft;
        });
        $(document).mouseup(function(){
            isMOving = false; 
        });
        selectro.mousemove(function(target){
            if(isMOving== true){
                loadAppopriateImage(target.pageX - this.offsetLeft);
            }
        });

        selectro.bind("touchstart", function(target){
            console.log("sdhfhdf" + isMOving);
            isMOving =true;
            
            var actualTouch = target.ogrinialEvent.touches[0] || target.ogrinialEvent.changetouches[0];
            var currentX =  actualTouch.clientX;
        });
        
        $(document).bind("touchend", function(target){
            console.log("sdhfhdf djfhhff" + isMOving);
            isMOving= false;
        });
        
        selectro.bind("touchmove", function(target){
            target.prevetnDefault();
            var actualTouch = target.ogrinialEvent.touches[0] || target.ogrinialEvent.changetouches[0];
        });


        function loadAppopriateImage(newX){
            if(currentX - newX > 25){
                currentX= newX;

                currentImage = -currentImage< 1? totalImage: currentImage;
                console.log("currentImage"+ currentImage);
                selectro.css("background-image", "url(" + imagePath + currentImage + "."+ imgageExtension);
                
            }
        }
        function forceAllImage(){
            var load_image = 2;
            var approxiamtelyImageURL = imgaePath +"l" + imgageExtension;
            selectro.css("background-image",'url('+ approxiamtelyImageURL+ ")");

            $("<img/>").attr("src", approxiamtelyImageURL)
                .load(function(){
                    selectro.height(this.height).width(this.width);
                });
            for(var i =2; i <= totalImage; i++){
                approxiamtelyImageURL = imagePath + i + "." + ImgaeExtension;
                selectro.append("<img src='" + approxiamtelyImageURL +" ' style= 'display:none;' ");
            }   
            $("<img/>").attr("src", approxiamtelyImageURL)
                .load(function(){
                selectro.height(this.height).width(this.width);
            });
        }
    }
}