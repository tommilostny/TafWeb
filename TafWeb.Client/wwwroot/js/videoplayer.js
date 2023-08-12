export function initVideoPlayer() {
	const element = document.getElementById('player');
	console.log(element);
	const player = new Plyr(element);

	//player = new Plyr('#player', {
	//	resetOnEnd: true,
	//	ratio: '20:9',
	//	loop: { active: true },
	//	clickToPlay: true,
	//});
	console.log(player);

	//screen.orientation.addEventListener("change", (event) => {
	//	switch (event.target.type) {
	//		case "landscape-primary":
	//		case "landscape-secondary":
	//			if (/*window.scrollY < 770 ||*/ player.playing) {
	//				player.fullscreen.enter();
	//			}
	//			break;
	//		default:
	//			if (player.fullscreen.active) {
	//				//document.getElementsByClassName("video-wrapper")[0].scrollIntoView();
	//				//window.scrollBy(0, -250);
	//				player.fullscreen.exit();
	//			}
	//			break;
	//	}
	//});
}