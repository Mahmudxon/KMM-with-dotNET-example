package uz.uniconsoft.messenger

fun getPlatformName(): String {
    return "Windows (version detection failed)"
}

class WindowsPlatform : Platform {
    override val name: String = getPlatformName()
}

actual fun getPlatform(): Platform = WindowsPlatform()