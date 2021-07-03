# This file is responsible for configuring your application
# and its dependencies with the aid of the Mix.Config module.
#
# This configuration file is loaded before any dependency and
# is restricted to this project.

# General application configuration
use Mix.Config

config :media_server,
  ecto_repos: [MediaServer.Repo]

# Configures the endpoint
config :media_server, MediaServerWeb.Endpoint,
  url: [host: "localhost"],
  secret_key_base: "KxK9NbNEAE0U3HXsgXmL/h/zeB69AP8Nk3rCGOnLIP06LDtUSdGJbfrylLlW32oN",
  render_errors: [view: MediaServerWeb.ErrorView, accepts: ~w(html json), layout: false],
  pubsub_server: MediaServer.PubSub,
  live_view: [signing_salt: "ie9UTXQA"]

# Configures Elixir's Logger
config :logger, :console,
  format: "$time $metadata[$level] $message\n",
  metadata: [:request_id]

# Use Jason for JSON parsing in Phoenix
config :phoenix, :json_library, Jason

# Import environment specific config. This must remain at the bottom
# of this file so it overrides the configuration defined above.
import_config "#{Mix.env()}.exs"
