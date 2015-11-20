'use strict';

galleryApp.controller('HomeController', function HomeController($scope) {
    $scope.towns = [
        {
            url: "http://img.photo-forum.net/site_pics//panorama/1434220762_12.jpg",
            name: 'Kyustendil'
        },
        {
            url: "https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152",
            name: 'Plovdiv'
        },
        {
            url: "http://img.photo-forum.net/site_pics//panorama/1401794484_DSC_1091.jpg",
            name: 'Dobrich'
        },
        {
            url: "http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w",
            name: 'Kyustendil'
        },
        {
            url: "http://i66.tinypic.com/33kesdi.jpg",
            name: 'Varna'
        },
        {
            url: "http://i64.tinypic.com/2vcxlpd.jpg",
            name: 'Burgas'
        },
    ];
});
