'use strict';

galleryApp.controller("WallOfFameController", function WallOfFameController($scope, $location){
    var isLogged = localStorage.getItem('isLoggedIn');

    if (!isLogged) {
        $location.path('/signin');
    }

    $scope.best = [
        {
            cityName: 'Kystendil',
            likes: 5,
            picture: 'http://static1.squarespace.com/static/54a674c9e4b0375c08453705/54d3e872e4b06da65e8a6a1a/54d93539e4b0853cc2aff163/1442931501486/Kyustendil_night.jpg?format=1500w'
        },
        {
            cityName: 'Kystendil',
            likes: 5,
            picture: 'http://img.photo-forum.net/site_pics//panorama/1434220762_12.jpg'
        },
        {
            cityName: 'Kystendil',
            likes: 2,
            picture: 'http://i2.offnews.bg/galleries/21441/20150224_2a38a4a9316c49e5a833517c45d31070_21445.jpg'
        },
        {
            cityName: 'Burgas',
            likes: 1,
            picture: 'http://i64.tinypic.com/2vcxlpd.jpg'
        }
    ];

    var currentUser = localStorage.getItem('username');
    var currentChannel = 'Bulgaria best town - wall of fame';

    var input = $('#chat-input');
    var output = $('#chat-output');

    var pubnub = PUBNUB.init({
        publish_key: 'pub-c-b333b488-6cc7-46ea-adc3-6c45b197c30b',
        subscribe_key: 'sub-c-ba358d14-8be7-11e5-8b47-02ee2ddab7fe'
    });

    $('#chat').submit(function() {

        pubnub.publish({
            channel: currentChannel,
            message: {
                text: input.val(),
                username: currentUser
            }
        });

        input.val('');

        return false;
    });

    pubnub.subscribe({
        channel: currentChannel,
        message: function(data) {

            var $line = $('<li class="list-group-item"><strong>' + data.username + ':</strong> </span>');
            var $message = $('<span class="text" />').html(parseMessage(data.text));

            if(data.username === currentUser) {
                $line.addClass('my-self');
                $message.addClass('me-self-message')
            }

            $line.append($message);
            output.append($line);

            output.scrollTop(output[0].scrollHeight);
        }
    });

    function parseMessage(message){
        // Prevent hacking
        var message = message.replace('<script>', '');

        var parsedMessage = '',
            laughingEmoticon = '<img class="emoticon" src="./content/media/emoticons/laughing.png"/>',
            likeEmoticon = '<img class="emoticon" src="./content/media/emoticons/like.png"/>',
            sadEmoticon = '<img class="emoticon" src="./content/media/emoticons/sad.png"/>',
            smileEmoticon = '<img class="emoticon" src="./content/media/emoticons/smile.png"/>',
            winkEmoticon = '<img class="emoticon" src="./content/media/emoticons/wink.png"/>',
            awesomeEmoticon = '<img class="emoticon" src="./content/media/emoticons/awesome.png"/>',
            tongueEmoticon = '<img class="emoticon" src="./content/media/emoticons/tongue.png"/>';

        // Parser
        for (var i = 0; i < message.length; i++){
            if (message[i] === ':' && (message[i + 1] === 'D' || message[i + 1] === 'd')) {
                parsedMessage += laughingEmoticon;
                i += 1;
            } else if (message[i] === ':' && message[i + 1] === ')') {
                parsedMessage += smileEmoticon;
                i += 1;
            } else if (message[i] === ':' && message[i + 1] === '(') {
                parsedMessage += sadEmoticon;
                i += 1;
            } else if (message[i] === ';' && message[i + 1] === ')') {
                parsedMessage += winkEmoticon;
                i += 1;
            } else if (message[i] === '(' && (message[i + 1] === 'y' || message[i + 1] === 'Y') && message[i + 2] === ')') {
                parsedMessage += likeEmoticon;
                i += 2;
            }  else if (message[i] === ':' && message[i + 1] === '3'){
                parsedMessage += awesomeEmoticon;
                i += 1;
            } else if (message[i] === ':' && (message[i + 1] === 'P' || message[i + 1] === 'p')){
                parsedMessage += tongueEmoticon;
                i += 1;
            } else {
                parsedMessage += message[i];
            }
        }

        return parsedMessage;
    }
});