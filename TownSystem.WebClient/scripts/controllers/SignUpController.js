'use strict';

galleryApp.controller('SignUpController', function SignUpController(userAuthentication, $scope, $resource, $location) {
    $scope.signUp = function () {
        userAuthentication.register($scope.firstname, $scope.lastname, $scope.username, $scope.password, $scope.email)
            .then(function () {
                $location.path('/signin');
            });
    };
});