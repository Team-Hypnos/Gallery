'use strict';

galleryApp.controller('MainController', function MainController($scope, author, copyright) {
    $scope.author = author;
    $scope.copyright = copyright;

    $scope.signOut = function () {
        $scope.isLoggedIn = false;
        $scope.path('/home');
        localStorage.clear();
    };

    if (localStorage.getItem('isLoggedIn')) {
        $scope.isLoggedIn = true;
        $scope.username = localStorage.getItem('username');
    }
});