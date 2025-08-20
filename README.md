# Animation Rigging

This Unity project demonstrates real-time body tracking and retargeting using Google's **MediaPipe** via the [homuler/MediaPipeUnityPlugin](https://github.com/homuler/MediaPipeUnityPlugin).
It takes **2D images, video, or live webcam input** and estimates 3D body joint positions, which are then mapped to a **standard Mixamo skeleton** using Unity’s **Animation Rigging** system.

![alt text](AnimationRiggingDemo.gif "Animation Rigging Demo")

## Features

* Input from **image, video, or webcam**
* **MediaPipe body tracking** via homuler’s Unity plugin
* Real-time mapping of 3D joint estimations to a Mixamo skeleton
* Retargeting handled with Unity’s **Animation Rigging package**