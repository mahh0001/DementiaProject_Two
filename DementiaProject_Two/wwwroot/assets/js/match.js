const likeButton = document.querySelector('#swipe_like')
const dislikeButton = document.querySelector('#swipe_dislike')
const profileImg = document.querySelector('#userviewimg')
var counter = 0;

function showNextProfile() {
    // Skift af billede kun til test, indtil vi får indlæst de rigtige billeder
    if (counter >= 9) counter = 0;
    counter++
    profileImg.src = "/images/pic0"+counter+".jpg"
}


likeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede like')

});
dislikeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede dislike')

})