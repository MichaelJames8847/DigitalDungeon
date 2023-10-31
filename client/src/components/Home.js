import React from "react"
import "./Home.css"

export default function Home() {
    return (
        <>
            <main>
                <h1>Welcome to DigitalDungeon!</h1>
                <div className="welcome">
                    <h2>Discover Your Next Gaming Adventure!</h2>
                    <p>Are you overwhelmed by the vast world of games, not knowing where to dive in next?
                        At DigitalDungeon, we curate a gaming experience tailored just for you. 
                        Our platform takes your gaming preferences into account and provides recommendations
                        that align perfectly with what you love.
                    </p>
                    <h3>Why Choose DigitalDungeon?</h3>
                    <ul>
                        <h4>Personalized Game Suggestions:</h4>
                        <li>Don't get lost in the crowd. Your unique gaming style deserves handpicked suggestions.</li>
                        <h4>Easily Manage Your Recommendations:</h4>
                        <li>Not every suggestion will be a hit. Easily remove games you're not interested in or suggest new ones to be added.</li>
                        <h4>Engage With The Gaming Community:</h4>
                        <li>Suggest new games, provide feedback, and be part of a community that's shaping the future of DigitalDungeon.</li>
                        <h4>Admin Features:</h4>
                        <li>Are you an admin? Manager the gaming catalog, user suggestions, and more with robust admin tools.</li>
                    </ul>
                    <h3>Join The Revolution</h3>
                    <p>Experience a fresh way to discover games. Join DigitalDungeon today, set up your profile, and 
                        embark on new gaming journeys curated just for you.
                    </p>
                </div>
            </main>
        </>
    )
}