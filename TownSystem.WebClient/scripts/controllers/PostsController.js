'use strict';

galleryApp.controller('PostsController', function PostsController($scope, $location) {
    $scope.posts = [
        {
            picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            title: 'Night in Kyustendil',
            likes: 4,
            id: 0
        },
        {
            picture: "http://img.photo-forum.net/site_pics//panorama/1434220762_12.jpg",
            title: 'Kyustendil, Hisarluka',
            likes: 5,
            id: 1
        },
        {
            picture: "http://i2.offnews.bg/galleries/21441/20150224_2a38a4a9316c49e5a833517c45d31070_21445.jpg",
            title: 'Hisarluka during winter',
            likes: 1,
            id: 2
        }
    ];

    $scope.townName = 'Kyustendil';

    // TODO: validation for title of each post when gets data from database
    // TODO: like a post

    // Validation title length
    //if (testNameOne.length >= 15) {
    //    var index = testNameOne.indexOf(' ');
    //    $scope.townName = testNameOne.substring(0, index) + '...';
    //}

    $scope.like = 0;
    $scope.canVote = true;

    $scope.likePost = function (id) {
        $scope.posts[id].likes += 1;
    };

    $scope.openPost = function (id, townName) {
        var town = townName.toLowerCase().replace(' ', '');
        $location.path('/towns/' + town + '/' + (100 + id));
    };
});
