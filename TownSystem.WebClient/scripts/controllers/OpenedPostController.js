'use strict';

galleryApp.controller('OpenedPostController', function OpenedPostController($scope) {
    $scope.currentPost = {
        user: 'DimitarSD',
        picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
        title: 'Kjustendil',
        description: 'Snimka na Kjustendil ot kreposta Hisarluka',
        comments: [
            {
                content: 'Basi qkata gledka brat!! Evala!! Mn dobra snimka :). KN the best!! :D',
                timePosted: '07-11-2015 17:30',
                user: 'PeshoK'
            },
            {
                content: 'Na jivo e oshte po krasivo ;)',
                timePosted: '07-11-2015 16:17',
                user: 'Svetlai'
            },
            {
                content: 'Plovdiv maina rule!! Plovdiv the best!! :P',
                timePosted: '07-11-2015 16:59',
                user: 'HrisA'
            },
            {
                content: 'Bqgai ot tuka be HrisA che da ne ima kech :D',
                timePosted: '07-11-2015 17:01',
                user: 'PeshoK'
            }
        ],
        likes: 25,
        id: 1
    };
});