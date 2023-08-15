export function initVideoPlayer(element, autoPlay, dotnetInstance) {
	const player = new Plyr(element, {
		resetOnEnd: true,
		ratio: autoPlay ? '19:9' : '21:9',
		loop: { active: true },
		autoplay: autoPlay,
		clickToPlay: true,
	});
	player.once('ready', event => {
		const instance = event.detail.plyr;
		instance.muted = autoPlay;
		if (!autoPlay) {
			hideLoading(dotnetInstance);
		}
	});
	if (autoPlay) {
		player.once('playing', () => {
			hideLoading(dotnetInstance);
		});
	}
}

function hideLoading(dotnetInstance) {
	dotnetInstance.invokeMethodAsync('HideLoading');
}
