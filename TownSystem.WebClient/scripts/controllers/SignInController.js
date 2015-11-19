'use strict';

galleryApp.controller('SignInController', function SignInController($scope, $resource, userAuthentication, $location) {
    var defaultAvatarPicture = 'http://files.parsetfss.com/1ad00c84-7830-427f-ac8d-d4459361b5ce/tfss-905a97f8-9505-4ab1-aabc-5c3aef44cd35-avartar.jpeg';

    $scope.signIn = function () {
        userAuthentication.login($scope.username, $scope.password)
            .then(function (data) {
                window.location.reload();
                localStorage.setItem('isLoggedIn', true);
                localStorage.setItem('access_token', data.access_token);
                localStorage.setItem('username', $scope.username);
                localStorage.setItem('profilePicture', defaultAvatarPicture);
                $location.path('/home');
            });
    };
});
