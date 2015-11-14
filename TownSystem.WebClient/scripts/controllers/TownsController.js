'use strict';

galleryApp.controller('TownsController', function TownsController($scope, $location) {
    $scope.albums = [
        {
            picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            name: 'Blagoevgrad',
            size: 13
        },
        {
            picture: "http://birdsphotographer.com/wp-content/uploads/2014/02/sofia-izgrev-sunrise-landscape-peizaj-wwwBirdsPhotographerCom__Nikolay-Staykov-8798.jpg",
            name: 'Stara Zagora',
            size: 77
        },
        {
            picture: "http://www.doubletreebyhiltonglobalmediacenter.com/assets/HHNR/images/galleries/topwintercities/europe/Varna_2.1.2012_HR.jpg",
            name: 'Varna',
            size: 10
        },
        {
            picture: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            name: 'Plovdiv',
            size: 25
        },
        {
            picture: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            name: 'Kjustendil',
            size: 13
        },
        {
            picture: "http://birdsphotographer.com/wp-content/uploads/2014/02/sofia-izgrev-sunrise-landscape-peizaj-wwwBirdsPhotographerCom__Nikolay-Staykov-8798.jpg",
            name: 'Sofia',
            size: 7
        },
        {
            picture: "http://www.doubletreebyhiltonglobalmediacenter.com/assets/HHNR/images/galleries/topwintercities/europe/Varna_2.1.2012_HR.jpg",
            name: 'Varna',
            size: 10
        },
        {
            picture: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            name: 'Plovdiv',
            size: 25
        }
    ];

    $scope.openAlbum = function (townName) {
        $location.path('/towns/' + townName.toLowerCase() + '/');
    };
});