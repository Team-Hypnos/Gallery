'use strict';

galleryApp.controller('CategoriesController', function CategoriesController($scope, $location) {
    $scope.categories = {
        nature: [
            {
                picture: 'http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w',
                town: 'Kyustendil',
                likes: 5,
                category: 'Nature',
                id: 0
            },
            {
                picture: 'http://img.photo-forum.net/site_pics//panorama/1434220762_12.jpg',
                town: 'Kyustendil',
                likes: 5,
                category: 'Nature',
                id: 1
            },
            {
                picture: 'http://i2.offnews.bg/galleries/21441/20150224_2a38a4a9316c49e5a833517c45d31070_21445.jpg',
                town: 'Kjustendil',
                likes: 2,
                category: 'Nature',
                id: 2
            },
            {
                picture: 'http://i66.tinypic.com/33kesdi.jpg',
                town: 'Varna',
                likes: 0,
                category: 'Nature',
                id: 3
            },
            {
                picture: 'http://img.photo-forum.net/site_pics//panorama/1401794484_DSC_1091.jpg',
                town: 'Dobrich',
                likes: 0,
                category: 'Nature',
                id: 4
            },
            {
                picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152',
                town: 'Plovdiv',
                likes: 0,
                category: 'Nature',
                id: 5
            },
            {
                picture: 'http://i64.tinypic.com/2vcxlpd.jpg',
                town: 'Burgas',
                likes: 1,
                category: 'Nature',
                id: 6
            }]
    };

    $scope.openPost = function (id, townName) {
        var town = townName.toLowerCase().replace(' ', '');
        $location.path('/towns/' + town + '/' + (100 + id));
    };

    $scope.canVote = true;

    $scope.voteForPost = function (category, id){
            $scope.categories[category][id].likes += 1;
    };
});