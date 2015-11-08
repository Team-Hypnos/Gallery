'use strict';

galleryApp.controller('ProfileController', function ProfileController($scope){
    if (localStorage.getItem('isLoggedIn')) {
        $scope.username = localStorage.getItem('username');
    }
});