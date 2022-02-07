// Wavesurfer Init

var wavesurfer = WaveSurfer.create({
    container: '#waveform',
    waveColor: 'violet',
    progressColor: 'purple'
});


let defaul_audio_path = "/audios/song.mp3";

wavesurfer.load(defaul_audio_path);


function addToPlayer(audio_path) {
    wavesurfer.load(audio_path);
    console.log(audio_path)
};

let play = () => wavesurfer.play();

let pause = () => wavesurfer.pause();

let skipForward = () => wavesurfer.skipForward();

let toggleMute = () => wavesurfer.toggleMute();