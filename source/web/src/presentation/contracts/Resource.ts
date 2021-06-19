type Resource = {
  Login: {
    Slogan: string,
    Message: string
  }
  User: {
    Info: {
      BirthDate: string,
      JoinDate: string
    },
    Connections: {
      Following: string,
      Followers: string
    }
  }
  Peep: {
    Publication: {
      Month: {
        January: string,
        February: string,
        March: string,
        April: string,
        May: string,
        June: string,
        July: string,
        August: string,
        September: string,
        October: string,
        November: string,
        December: string
      }
    }
    Interactions: {
      Replies: string,
      Quotes: string,
      Reposts: string,
      Likes: string
    }
  }
}

export default Resource 