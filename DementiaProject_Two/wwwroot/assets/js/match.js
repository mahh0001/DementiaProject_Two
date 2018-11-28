const likeButton = document.querySelector('#swipe_like')
const dislikeButton = document.querySelector('#swipe_dislike')


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

window.onload = function () {
    showNextProfile()
}
likeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede like')

});
dislikeButton.addEventListener('click', () => {
    showNextProfile()
console.log('Du trykkede dislike')

})