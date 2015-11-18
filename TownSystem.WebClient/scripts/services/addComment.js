'use strict';

galleryApp.factory('addComment', function ($resource, $q, $http) {
    var remoteUrl = 'http://localhost:6299/';

    return {
        addNewComment: function (commentObj) {
            var deferred = $q.defer();

            $http.post(remoteUrl + 'route', {
                postId: commentObj.postId,
                content: commentObj.content,
                postedOn: commentObj.postedOn,
                user: {
                    name: commentObj.user.name,
                    profilePicture: commentObj.user.profilePicture
                }
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    toastr.error('Something went wrong. Please try again.', '', {"positionClass": "toast-bottom-right"});
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    }
});