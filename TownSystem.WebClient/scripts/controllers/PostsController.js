'use strict';

galleryApp.controller('PostsController', function PostsController($scope, $location) {
    $scope.posts = [
        {
            picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            title: 'Kjustendil',
            likes: 63,
            id: 1
        },
        {
            picture: "http://birdsphotographer.com/wp-content/uploads/2014/02/sofia-izgrev-sunrise-landscape-peizaj-wwwBirdsPhotographerCom__Nikolay-Staykov-8798.jpg",
            title: 'Kjustendil',
            likes: 7,
            id: 2
        },
        {
            picture: "http://www.doubletreebyhiltonglobalmediacenter.com/assets/HHNR/images/galleries/topwintercities/europe/Varna_2.1.2012_HR.jpg",
            title: 'Kjustendil',
            likes: 10,
            id: 3
        },
        {
            picture: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            title: 'Kjustendil',
            likes: 45,
            id: 4
        },
        {
            picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            title: 'Kjustendil',
            likes: 13,
            id: 5
        },
        {
            picture: "http://birdsphotographer.com/wp-content/uploads/2014/02/sofia-izgrev-sunrise-landscape-peizaj-wwwBirdsPhotographerCom__Nikolay-Staykov-8798.jpg",
            title: 'Kjustendil',
            likes: 1,
            id: 6
        },
        {
            picture: "http://www.doubletreebyhiltonglobalmediacenter.com/assets/HHNR/images/galleries/topwintercities/europe/Varna_2.1.2012_HR.jpg",
            title: 'Kjustendil',
            likes: 10,
            id: 7
        },
        {
            picture: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            title: 'Kjustendil',
            likes: 25,
            id: 8
        },
        {
            picture: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            title: 'Kjustendil',
            likes: 45,
            id: 9
        }
    ];
    var testNameOne = 'Kjustendil i moreto, i moreto ';

    // TODO: validation for title of each post when gets data from database
    // TODO: like a post

    // Validation title length
    if (testNameOne.length >= 15) {
        var index = testNameOne.indexOf(' ');
        $scope.townName = testNameOne.substring(0, index) + '...';
    }

    $scope.like = 0;
    $scope.canVote = true;

    $scope.likePost = function () {
        debugger;
        if (!$scope.canVote) {
            $scope.like -= 1;
            $scope.canVote = true;
        } else {
            $scope.like += 1;
            $scope.canVote = false;
        }
    };

    $scope.openPost = function (id, townName) {
        var town = townName.toLowerCase().replace(' ', '');
        $location.path('/towns/' + town + '/' + (100 + id));
    };
});
