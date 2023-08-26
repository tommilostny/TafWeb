/**
 * @param {any} element
 * @param {boolean} autoPlay
 * @param {{ invokeMethodAsync: (method: string) => void; }} dotnetInstance
 */
export function initVideoPlayer(element, autoPlay, dotnetInstance) {
	// @ts-ignore
	const player = new Plyr(element, {
		resetOnEnd: true,
		ratio: autoPlay ? '19:9' : '21:9',
		loop: { active: true },
		autoplay: autoPlay,
		clickToPlay: true,
	});
	player.once('ready', (/** @type {{ detail: { plyr: any; }; }} */ e) => {
		const instance = e.detail.plyr;
		instance.muted = autoPlay;
		if (!autoPlay) {
			dotnetInstance.invokeMethodAsync('HideLoading');
		}
	});
	if (autoPlay) {
		player.once('playing', () => {
			dotnetInstance.invokeMethodAsync('HideLoading');
		});
	}
}
