defmodule MediaServer.ProfileImages.ProfileImage do
  use Ecto.Schema
  import Ecto.Changeset

  @primary_key {:id, :binary_id, autogenerate: true}
  @foreign_key_type :binary_id
  @required_fields [
    :user,
    :image
  ]

  schema "profile_image" do
    field :image, :binary
    field :user, Ecto.UUID

    timestamps()
  end

  @doc false
  def changeset(profile_image, attrs) do
    profile_image
    |> cast(attrs, @required_fields)
    |> validate_required(@required_fields)
  end
end
