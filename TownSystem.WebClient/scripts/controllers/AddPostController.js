'use strict';

galleryApp.controller('AddPostController', function AddPostController($scope, $location, createPost) {
    var isLogged = localStorage.getItem('isLoggedIn');

    if (!isLogged) {
        $location.path('/signin');
    }

    $scope.townsCollection = [
        {
            value: 'Aitos',
            label: 'Aitos'
        },
        {
            value: 'Asenovgrad',
            label: 'Asenovgrad'
        },
        {
            value: 'Blagoevgrad',
            label: 'Blagoevgrad'
        },
        {
            value: 'Botevgrad',
            label: 'Botevgrad'
        },
        {
            value: 'Burgas',
            label: 'Burgas'
        },
        {
            value: 'Chirpan',
            label: 'Chirpan'
        },
        {
            value: 'Dobrich',
            label: 'Dobrich'
        },
        {
            value: 'Dupnica',
            label: 'Dupnica'
        },
        {
            value: 'Gabrovo',
            label: 'Gabrovo'
        },
        {
            value: 'Gotse Delchev',
            label: 'Gotse Delchev'
        },
        {
            value: 'Haskovo',
            label: 'Haskovo'
        },
        {
            value: 'Kardzhali',
            label: 'Kardzhali'
        },
        {
            value: 'Karlovo',
            label: 'Karlovo'
        },
        {
            value: 'Karnobat',
            label: 'Karnobat'
        },
        {
            value: 'Kazanlak',
            label: 'Kazanlak'
        },
        {
            value: 'Kyustendil',
            label: 'Kyustendil'
        },
        {
            value: 'Lom',
            label: 'Lom'
        },
        {
            value: 'Lovech',
            label: 'Lovech'
        },
        {
            value: 'Montana',
            label: 'Montana'
        },
        {
            value: 'Nova Zagora',
            label: 'Nova Zagora'
        },
        {
            value: 'Panagurishte',
            label: 'Panagurishte'
        },
        {
            value: 'Pazardzhik',
            label: 'Pazardzhik'
        },
        {
            value: 'Pernik',
            label: 'Pernik'
        },
        {
            value: 'Petrich',
            label: 'Petrich'
        },
        {
            value: 'Pleven',
            label: 'Pleven'
        },
        {
            value: 'Plovdiv',
            label: 'Plovdiv'
        },
        {
            value: 'Razgrad',
            label: 'Razgrad'
        },
        {
            value: 'Ruse',
            label: 'Ruse'
        },
        {
            value: 'Samokov',
            label: 'Samokov'
        },
        {
            value: 'Sandanski',
            label: 'Sandanski'
        },
        {
            value: 'Sevlievo',
            label: 'Sevlievo'
        },
        {
            value: 'Shumen',
            label: 'Shumen'
        },
        {
            value: 'Silistra',
            label: 'Silistra'
        },
        {
            value: 'Sliven',
            label: 'Sliven'
        },
        {
            value: 'Smolian',
            label: 'Smolian'
        },
        {
            value: 'Sofia',
            label: 'Sofia'
        },
        {
            value: 'Stara Zagora',
            label: 'Stara Zagora'
        },
        {
            value: 'Svilengrad',
            label: 'Svilengrad'
        },
        {
            value: 'Troyan',
            label: 'Troyan'
        },
        {
            value: 'Varna',
            label: 'Varna'
        },
        {
            value: 'Veliko Tarnovo',
            label: 'Veliko Tarnovo'
        },
        {
            value: 'Velingrad',
            label: 'Velingrad'
        },
        {
            value: 'Vidin',
            label: 'Vidin'
        },
        {
            value: 'Vratsa',
            label: 'Vratsa'
        },
        {
            value: 'Yambol',
            label: 'Yambol'
        }
    ];
    $scope.categoriesCollection = [
        {
            value: 'Nature',
            label: 'Nature'
        },
        {
            value: 'Historical monuments',
            label: 'Historical monuments'
        },
        {
            value: 'City life',
            label: 'City life'
        },
        {
            value: 'City culture',
            label: 'City culture'
        },
        {
            value: 'City festivals',
            label: 'City festivals'
        }
    ];

    $scope.addNewPost = function () {
        var fileData = new FormData();

        var files = $('#image-input').get(0).files;

        if (files.length > 0) {
            fileData.append($scope.postTitle, files[0]);
        }

        var post = {
            title: $scope.postTitle,
            description: $scope.postDescription,
            townName: $scope.townsList.label,
            townCategory: $scope.categoriesList.label,
            pictureData: fileData
        };

        createPost.createNewPost(post)
            .then(function () {
                $location.path('/home');
            })
    };

});