const likeButton = document.querySelector('#swipe_like')
const dislikeButton = document.querySelector('#swipe_dislike')
const profileImg = document.querySelector('#userviewimg')
var counter = 0;

function showNextProfile() {
    $.ajax({
        url: '/match/next',
        type: 'GET',
        dataType: 'html',
        success: function (data) {
            $('.userViewContainer').html(data);
        }, 
        error: function(errorData) {
            console.log(errorData)
        }
    });
}


likeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede like')

});
dislikeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede dislike')

})