const eye = document.getElementById('creepyEye')
let clickCount = 0;
document.addEventListener('DOMContentLoaded', () => {
    eye.addEventListener('click', hideEye);
    function hideEye(){
        
        let childList = [];
        eyeText = document.querySelector('#backStory');
        if (eyeText.classList.contains('hidden')){
            eyeText.classList.remove('hidden')
        }
        else{
            eyeText.setAttribute('class', 'hidden');
        }

            
        }
        const bait = document.getElementById('clickBait');
        bait.addEventListener('click', clickBaitFunction);
        function clickBaitFunction(){
            if (clickCount == 0){
                bait.innerText = "You just let an ugly website " +
                "tell you what to do, click again to hide your shame";
                clickCount++;
            }
            else if (clickCount == 1) {
                bait.innerText = "STOP LISTENING TO ME YOU ABSOLUTE BAFOON";
                clickCount = 0;
            }

        }

    });