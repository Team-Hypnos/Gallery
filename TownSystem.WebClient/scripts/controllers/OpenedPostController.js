'use strict';

galleryApp.controller('OpenedPostController', function OpenedPostController($scope, addComment) {
    $scope.currentPost = {
        user: 'DimitarSD',
        picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
        title: 'Kjustendil',
        description: 'Snimka na Kjustendil ot kreposta Hisarluka',
        comments: [
            {
                content: 'Basi qkata gledka brat!! Evala!! Mn dobra snimka :). KN the best!! :D',
                timePosted: '07-11-2015 17:30',
                user: 'PeshoK',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xft1/v/t1.0-1/p160x160/11999015_880313535371661_4514415029939989086_n.jpg?oh=04aeeb0a0af03aa0db38faaa18035ffe&oe=56BAB54F'
            },
            {
                content: 'Na jivo e oshte po krasivo ;)',
                timePosted: '07-11-2015 16:17',
                user: 'Svetlai',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xtf1/v/t1.0-1/p160x160/11221958_962511663792625_2132890249722016801_n.jpg?oh=482717fbaa4006e421e2f38b8931b502&oe=56F18776'
            },
            {
                content: 'Plovdiv maina rule!! Plovdiv the best!! :P',
                timePosted: '07-11-2015 16:59',
                user: 'HrisA',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xfp1/v/t1.0-1/p160x160/10155933_1141718899187094_5809720026873697966_n.jpg?oh=62abc83ccc5045be2b327d737e741a1d&oe=56B8B154'
            },
            {
                content: 'Bqgai ot tuka be HrisA che da ne ima kech :D',
                timePosted: '07-11-2015 17:01',
                user: 'PeshoK',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xft1/v/t1.0-1/p160x160/11999015_880313535371661_4514415029939989086_n.jpg?oh=04aeeb0a0af03aa0db38faaa18035ffe&oe=56BAB54F'
            }
        ],
        likes: 25,
        id: 1
    };
    // Gets current post -> GET
    var postId = 1;

    // Using the ID from the current post -> POST
    $scope.addNewComment = function () {
        var newDate = new Date();
        var datetime = newDate.today() + ' ' + newDate.timeNow(); // format -> 18/11/2015 03:11:55

        var commentObj = {
            postId: postId,
            content: $scope.commentContent,
            postedOn: datetime,
            user: {
                name: localStorage.getItem('username'),
                profilePicture: localStorage.getItem('profilePicture') // need to be changed
            }
        };
        
        if (typeof($scope.commentContent) !== 'undefined') {
            addComment.addNewComment(commentObj)
                .then(function () {
                    window.location.reload();
                });
        } else {
            toastr.warning('Cannot add an empty comment!', '', {"positionClass": "toast-bottom-right"})
        }
    };

    // For today's date;
    Date.prototype.today = function () {
        return ((this.getDate() < 10) ? "0" : "") + this.getDate() + "/" + (((this.getMonth() + 1) < 10) ? "0" : "") + (this.getMonth() + 1) + "/" + this.getFullYear();
    };

    // For the time now
    Date.prototype.timeNow = function () {
        return ((this.getHours() < 10) ? "0" : "") + this.getHours() + ":" + ((this.getMinutes() < 10) ? "0" : "") + this.getMinutes() + ":" + ((this.getSeconds() < 10) ? "0" : "") + this.getSeconds();
    };
});