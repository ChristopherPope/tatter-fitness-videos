const grid = document.querySelector(".mvc-grid");

const videoButtonsId = "video-buttons";
const videoButtonsSelector = `#${videoButtonsId}`

var buttonsContainer = $("#buttons-container");

//////////////////////////////////////////////////////////////////////////////////
document.addEventListener('rowclick', e => {
    $('.selected-row').removeClass('selected-row');
    $(e.srcElement).addClass('selected-row');

    buttonsContainer.empty();
    buttonsContainer.append(`<div id='${videoButtonsId}'></div>`);
    var buttons = $(videoButtonsSelector);

    var videoIdsJson = e.detail.data.VideoIds;
    console.info(videoIdsJson);
    var videoIds = JSON.parse(videoIdsJson);

    //buttons.append(`<input type="radio" id="all-videos" video-ids-json='${videoIdsJson}' name="video-radio"><label for="all-videos">All Videos</label>`);

    videoIds.forEach((videoId, index) => {
        videoIdsJson = `[${videoId}]`;
        var checked = index == 0 ? "checked" : "";
        buttons.append(`<input type="radio" ${checked} id="video${index + 1}" video-ids-json='${videoIdsJson}' name="video-radio"><label for="video${index + 1}">Video${index + 1}</label>`);
    });

    buttons.buttonset();

    $("[name='video-radio']").click(onShowVideo);

    var btn = $("#video1")[0];
    onShowVideo({ currentTarget: btn });
});

////////////////////////////////////////////////////////////////////////////////////
function onShowVideo(e) {
    var button = $(e.currentTarget);
    var videoIdsJson = button.attr("video-ids-json");
    var videoIds = JSON.parse(videoIdsJson);

    var sources = [];
    videoIds.forEach(videoId => {
        sources.push({ src: `/Video/index/${videoId}`, type: 'video/mp4' });
    });

    var player = videojs.getPlayer('tatter-video');
    player.src(sources);
};



