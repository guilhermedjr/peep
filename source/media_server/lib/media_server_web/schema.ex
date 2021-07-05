defmodule MediaServerWeb.Schema do
  use Absinthe.Schema

  alias MediaServer.PeepMediaContent

  import_types MediaServerWeb.Schema.Types
  import_types Absinthe.Plug.Types

  # @type PeepMedia :: %{
  #   index: integer,
  #   media: :upload,
  #   media_type: integer
  # }

  query do
    @desc "Get the media of a specific peep"
    field :peep_media_content, list_of(:peep_media) do
      arg :peep, non_null(:string)
      resolve fn args ->
        {:ok, PeepMediaContent.list_peep_media(args[0])}
      end
    end
  end

  mutation do
    @desc "Upload media of a specific peep"
    field :peep_media_upload, :string do
      arg :peep, non_null(:string)
      arg :media, non_null(:upload) # make this be a array of PeepMedia
      resolve fn _args ->
        {:ok, "success"}
      end
    end
  end
end
