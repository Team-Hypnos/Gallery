'use strict';

galleryApp.controller('OpenedPostController', function OpenedPostController($scope, addComment) {
    $scope.currentPost = {
        user: 'DimitarSD',
        picture: "http://i65.tinypic.com/qys2sk.png",
        title: 'Sofia in Sunrise ',
        description: 'A beautiful picture of Sofia taken from Vitosha during the sunrise.',
        comments: [
            {
                content: 'Basi qkata gledka brat!! Evala!! Mn dobra snimka :).',
                timePosted: 'Nov 20, 2015 - 16:30',
                user: 'PeshoK',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hphotos-xat1/v/t1.0-9/s720x720/11052000_1130550310475329_3811627623858465299_n.jpg?oh=be29bf4ce0093aeab4e72865a748a5d0&oe=56F613DA'
            },
            {
                content: 'Na jivo e oshte po krasivo ;)',
                timePosted: 'Nov 20, 2015 - 17:17',
                user: 'SvetlaI',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xtf1/v/t1.0-1/p160x160/11221958_962511663792625_2132890249722016801_n.jpg?oh=482717fbaa4006e421e2f38b8931b502&oe=56F18776'
            },
            {
                content: 'Plovdiv maina rule!! Plovdiv the best!! :P',
                timePosted: 'Nov 20, 2015 - 17:59',
                user: 'HrisA',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hprofile-xfp1/v/t1.0-1/p160x160/10155933_1141718899187094_5809720026873697966_n.jpg?oh=62abc83ccc5045be2b327d737e741a1d&oe=56B8B154'
            },
            {
                content: 'Momche po-poleka!! Shte ima kech :D',
                timePosted: 'Nov 20, 2015 - 18:09',
                user: 'PeshoK',
                userPicture: 'https://scontent-frt3-1.xx.fbcdn.net/hphotos-xat1/v/t1.0-9/s720x720/11052000_1130550310475329_3811627623858465299_n.jpg?oh=be29bf4ce0093aeab4e72865a748a5d0&oe=56F613DA'
            }
        ],
        likes: 5,
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