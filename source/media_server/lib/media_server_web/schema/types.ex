defmodule MediaServerWeb.Schema.Types do
  use Absinthe.Schema.Notation

  # import_types Absinthe.Plug.Types

  object :profile_image do
    # field :id, :binary_id
    field :user, :string
    # field :image, :upload
  end

  object :peep_media do
    # field :id, :binary_id
    field :peep, :string
    field :index, :integer
    # field :media, :upload
    field :media_type, :integer
  end
end
