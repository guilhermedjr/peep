defmodule MediaServer.PeepMediaContent.PeepMedia do
  use Ecto.Schema
  import Ecto.Changeset

  @primary_key {:id, :binary_id, autogenerate: true}
  @foreign_key_type :binary_id
  @required_fields [
    :peep,
    :index,
    :media,
    :media_type
  ]

  schema "peep_media" do
    field :index, :integer
    field :media, :binary
    field :media_type, :integer
    field :peep, Ecto.UUID

    timestamps()
  end

  @doc false
  def changeset(peep_media, attrs) do
    peep_media
    |> cast(attrs, @required_fields)
    |> validate_required(@required_fields)
  end
end
