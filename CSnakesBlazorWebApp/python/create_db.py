import kuzu

def main() -> None:
    db = kuzu.Database("social_network.kuzu")
    conn = kuzu.Connection(db)

    conn.execute("""
        CREATE NODE TABLE IF NOT EXISTS User (
            user_id INT64 PRIMARY KEY,
            username STRING,
            account_creation_date DATE
        )""")
    conn.execute("""
        CREATE NODE TABLE IF NOT EXISTS Post (
            post_id INT64 PRIMARY KEY,
            post_date DATE,
            like_count INT64,
            retweet_count INT64
        )""")
    conn.execute("""
        CREATE REL TABLE IF NOT EXISTS FOLLOWS (
            FROM User TO User
        )""")
    conn.execute("""
        CREATE REL TABLE IF NOT EXISTS POSTS (
            FROM User TO Post
        )""")
    conn.execute("""
        CREATE REL TABLE IF NOT EXISTS LIKES (
            FROM User TO Post
        )""")

if __name__ == "__main__":
    main()