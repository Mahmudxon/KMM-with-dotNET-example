package uz.uniconsoft.messenger

interface Platform {
    val name: String
}

expect fun getPlatform(): Platform