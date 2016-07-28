# TweetBooty
Twitter Bot

This is a Twitter Bot experiment using C# and TweetMoaSharp.3.0 on a windows form app with a SQL Server database:

- Saving Hashtags on Search Queries
- Saving Tweeted tweets or Actions (Follows, Favs, RT's)
- Avoid Banned Words on the database
- Read a generated Sitemap XML file to save: Titles, Description and URL
- Use the saved links to tweet
- Use the saved hashtags to complete tweets
- Add media to tweets
- Randomize Actions on given time to avoid getting banned

This bot it's capable to tweet in a given period of time randomly, get the tweets from the database and use a bank of hashtags to make the tweets unique.

Used Libraries:
- EntityFramework.5.0.0
- TweetMoaSharp.3.0.0.15
- HtmlAgilityPack.1.4.9.4

Please visit http://controlzeta.com.mx/ 